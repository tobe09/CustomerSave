
namespace CustomerSave.Customer {

    export class Payment extends CustomerSave.General {

        private connection: signalR.HubConnection;

        private constants = {
            commentLinks: 'a:contains("Comment")',
            paymentIdKey: 'payment-id',
            itemIdKey: 'item-id',
            closeLinks: '.single-alert .close',
            dismissDelay: 500,
            alertRows: '.comment-alerts .single-alert',
            alertComments: '.comment-alerts .showCommentDiv',
            commentModalId: '#commentModal',
            commentContentId: '#commentBody'
        };

        constructor() {
            super();
            this.connection = this.getCommentHubConnection();
        }

        initializePage(): PromiseLike<void> {
            return this.connection.start().then(() => {
                this.removeSereneDefaults();
                this.handleAlertClick();
                this.handleAlertDismiss();
                this.setAlertMargin();
                this.handleCommentLinkClick();
                this.returnedCommentsForPayment();
                this.commentAddClick();
                this.commentReturnedAfterAdd();
                this.modalShown();
                this.modalHidden();
                console.log('connection started');
            }).catch(e => {
                if (e instanceof signalR.HttpError || e instanceof signalR.TimeoutError) {
                    console.log('Error type: ' + typeof e);
                    console.log('Error establishing connection');
                }
                else {
                    console.log('Initialization error has occured')
                    console.log((e as Error).message);
                }
            });
        }

        private removeSereneDefaults(): void {
            //attempt to remove serenity features from comment links
            $(this.constants.commentLinks).each((i, e) => {
                const that = $(e);
                that.attr('href', '#');
                that.removeClass('s-Customer-PaymentLink');
                that.attr('data-item-type', '');
            });
        }

        private handleAlertClick(): void {
            $(document).on('click', this.constants.alertComments, e => {
                const that = $(e.currentTarget);
                const singleAlertRow = that.parent();
                const paymentId = singleAlertRow.data(this.constants.paymentIdKey);            //get payment Id for alert

                const commentLink = $(this.constants.commentLinks).filter((i, e) => {     //find exact comment link for payment Id
                    return $(e).data(this.constants.itemIdKey) === paymentId;
                });

                this.commentClickDisplayInfo(commentLink);
            });

            //when link is clicked
            $(document).on('click', '.open-link', e => {
                const link = $(e.currentTarget);
                link.parent().siblings(this.constants.alertComments).click();   //invoke click of comment div
            });
        }

        private handleAlertDismiss(): void {
            $(document).on('click', this.constants.closeLinks, e => {
                const singleAlert = $(e.currentTarget).parent().parent();
                const paymentId = singleAlert.data(this.constants.paymentIdKey);

                singleAlert.detach();       //remove alert link
                this.setAlertMargin();

                this.UpdateCommentTrackForPayment(paymentId);
            });
        }

        private handleCommentLinkClick(): void {
            //attach handlers for comment links click
            $(this.constants.commentLinks).on('click', e => {
                const commentLink = $(e.currentTarget);

                return this.commentClickDisplayInfo(commentLink);
            });
        }

        commentClickDisplayInfo(commentLink: JQuery): boolean {
            const paymentId = commentLink.data(this.constants.itemIdKey);

            const commentModal = $(this.constants.commentModalId);
            commentModal.modal('show');
            commentModal.data(this.constants.paymentIdKey, paymentId);

            //append details to comment modal
            const div = commentLink.parent().parent();
            const customerId = div.find('div:eq(0)').text();
            const description = div.find('div:eq(3)').text();
            const amount = div.find('div:eq(2)').text();
            const date = div.find('div:eq(4)').text();

            $('#customerIdSpan').text(customerId);
            $('#descriptionSpan').text(description);
            $('#amountSpan').text(amount);
            $('#dateSpan').text(date);

            this.connection.invoke('GetCommentsForRecord', paymentId);  //get comments for payment record 

            return false;       //to stop event propagation
        }

        private returnedCommentsForPayment(): void {
            this.connection.on('displayCommentsForRecord', (comments: Array<IComment>) => {
                const commentContent = $(this.constants.commentContentId);

                const alert = $(this.constants.alertRows).filter((i, e) => {
                    if (comments.length > 0) {
                        return $(e).data(this.constants.paymentIdKey) === comments[0].paymentId;
                    }
                    else {
                        return false;
                    }
                })

                alert.detach();
                this.setAlertMargin();

                commentContent.html('');     //clear comment body for new values
                this.displayComments(comments, commentContent);
            });
        }

        private setAlertMargin(): void {
            const remaining = $(this.constants.alertRows).filter((i, e) => {
                return $(e).css('display') === 'block';
            }).length;

            if (remaining === 0) {
                $('.comment-alerts').css('margin-bottom', '0px');
            }
            else {
                $('.comment-alerts').css('margin-bottom', '15px');
            }
        }

        private commentAddClick(): void {
            //send comment to server
            $('#addCommentBtn').on('click', () => {
                const commentText = $('#commentInput').val();
                const paymentId = $(this.constants.commentModalId).data(this.constants.paymentIdKey);

                if (commentText === '' || commentText == null) {     //if no comment is entered
                    this.showErrorMsg("(No comment entered)", $('#errMsg'));
                }
                else {
                    $('#errMsg').text('');
                    $('#commentInput').val('');

                    this.connection.invoke('SaveComment', { commentText, paymentId });        //send comment to hub
                }
            });
        }

        private commentReturnedAfterAdd(): void {
            //handle event from signalR for comment added
            this.connection.on('commentAdded', ({ comment, paymentInfo }: { comment: IComment, paymentInfo: IPaymentInfo }) => {
                const commentModal = $(this.constants.commentModalId);
                const tabIsOpen = (commentModal.data(this.constants.paymentIdKey) === comment.paymentId) && (commentModal.css('display') === 'block');

                if (tabIsOpen) { //display comment if tab is open
                    this.displayComments([comment], $(this.constants.commentContentId));
                    this.scrollCommentBottom();
                }
                else {          //inform user with alert if payment's commnent tab is not open
                    const alertRow = $(this.constants.alertRows).filter((i, e) => {
                        const paymentId = $(e).data(this.constants.paymentIdKey);
                        return paymentId === comment.paymentId;
                    });

                    if (alertRow.length === 0) {  //attach alert
                        const commentAlerts = $('.comment-alerts');
                        const newAlert = this.singleAlertHtml(comment, paymentInfo);
                        commentAlerts.html(newAlert + commentAlerts.html());
                        this.setAlertMargin();
                    }
                    else {   //alert is among list of alerts, update values
                        const msgSpan = alertRow.find('.detail');
                        const text = msgSpan.text().trim();
                        const newText = this.newCountForText(text, 1);
                        msgSpan.text(newText);

                        const lastMsgSenderDiv = msgSpan.siblings('.last-comment-user');
                        lastMsgSenderDiv.text(`Last Commentator: ${comment.adminUsername.toUpperCase()} (${this.formatServerDate(comment.date)})`);
                    }
                }
            });
        }

        private singleAlertHtml(comment: IComment, paymentInfo: IPaymentInfo): string {
            return `<div class="row alert-success fade in single-alert" data-payment-id="${comment.paymentId}">
                    <div class="pull-right">
                        <a href="#" class="open-link">Open</a>
                        <a href="#" class="close">&times;</a>
                    </div>
                    <div class="showCommentDiv">
                        <div class="newCommentText">
                            <div class="col-md-4 detail">
                                1 unread comment for ${paymentInfo.customerGivenId}
                            </div>
                            <div class="col-md-3">
                                ${paymentInfo.description}
                            </div>
                            <div class="col-md-4 last-comment-user">
                                Last Commentator: ${comment.adminUsername.toUpperCase()} (${this.formatServerDate(comment.date)})
                            </div>
                        </div>
                    </div></div>`;
        }

        private displayComments(comments: Array<IComment>, commentBody: JQuery): PromiseLike<void> {
            let value = "";
            for (const comment of comments) {
                value += this.htmlText(comment);
            }

            commentBody.html(commentBody.html() + value);        //append text to comment body
            this.showNoOfComments(comments.length);

            const paymentId = $(this.constants.commentModalId).data(this.constants.paymentIdKey);

            return this.UpdateCommentTrackForPayment(paymentId);
        }

        private showNoOfComments(size: number): void {
            const msg = $('#commentMsg');
            if (msg.text() == '') {
                msg.text(`Number of comments: ${size}`)
            }
            else {
                const msgArr = msg.text().split(' ');
                const prevSize = parseInt(msgArr[msgArr.length - 1]);
                msg.text(`Number of comments: ${prevSize + size}`)
            }
        }

        private UpdateCommentTrackForPayment(paymentId: number): PromiseLike<void> {
            return this.connection.invoke('UpdateCommentTrackForPayment', paymentId);       //update user comment view history
        }

        private htmlText(comment: IComment): string {
            const formatNo = (no) => no < 10 ? '0' + no : '' + no;      //function to append '0' to a single digit number

            //convert date string to a presentable date
            const date = (function (dateString) {
                const dayOfWeek = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
                const innerDate = new Date(dateString);
                const formattedDate = `${dayOfWeek[innerDate.getDay()]}, ${innerDate.getDate()}/${innerDate.getMonth()}/${innerDate.getFullYear()} - 
                    ${innerDate.getHours()}:${formatNo(innerDate.getMinutes())}:${formatNo(innerDate.getSeconds())}`;

                return formattedDate;
            })(comment.date);

            let htmlValue = `<div class="row" style="background-color: bisque; padding:5px; margin:15px; margin-top:0px;"> 
                        <div class="col-sm-12" style="font-size:16px;padding-bottom:5px;">${comment.commentText}</div><div class="col-sm-4"></div>
                        <div class="col-sm-3 text-right"> <small><b>${comment.adminUsername.toUpperCase()}</b></small></div> 
                        <div class="col-sm-5 text-right"> <small>${date}</div> </small></div>`

            return htmlValue;
        }

        private modalShown(): void {
            //scroll to bottom of comments when it is opened
            $(this.constants.commentModalId).on('shown.bs.modal', () => {
                this.scrollCommentBottom();
            });
        }

        private modalHidden(): void {
            //clear values when modal is closed
            $(this.constants.commentModalId).on('hidden.bs.modal', () => {
                $('#commentMsg').text('');      //clear message count
                $('#errMsg').text('');          //clear error messageconst commentModal = $(Payment.constants.commentModalId);
                $(this.constants.commentModalId).data(this.constants.paymentIdKey, -1);
            });
        }

        private scrollCommentBottom(): void {
            const commentBody = $(this.constants.commentContentId);
            commentBody.animate({ scrollTop: commentBody.prop("scrollHeight") }, "slow");              //scroll to bottom of page
        }

    }

    export interface IComment {
        commentText: string;
        adminUsername: string;
        paymentId: number;
        date: string;
    }

    export interface IPaymentInfo {
        customerUsername: string;
        customerGivenId: string;
        description: string;
    }

}