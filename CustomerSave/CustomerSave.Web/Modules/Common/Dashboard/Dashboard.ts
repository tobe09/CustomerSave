
namespace CustomerSave.Customer {

    export class Dashboard extends CustomerSave.General {

        private connection: signalR.HubConnection;

        constructor() {
            super();
            this.connection = this.getCommentHubConnection();
        }

        initializepage(): void {
            this.connection.start().then(() => {
                this.onCommentAdded();
                console.log('connection started');
            });
        }

        private onCommentAdded(): void {
            //handle event from signalR for comment added
            this.connection.on('commentAdded', ({ comment, paymentInfo }: { comment: IComment, paymentInfo: IPaymentInfo }) => {
                const table = $('.comment-table');
                const row = table.find('tr').filter((i, e) => {
                    const paymentId = $(e).data('payment-id');
                    return paymentId === comment.paymentId;
                });

                if (row.length === 0) {  //attach alert
                    table.find('.table-header').css('display', '');     //to show table header
                    const newAlertHtml = this.getRowHtml(comment, paymentInfo);
                    $(newAlertHtml).insertAfter(".comment-table tr:first");

                    this.resetHeding(table);
                    this.resetSerialNo(table);
                }
                else {   //alert is among list of alerts, set new values
                    const cell = row.find('td:eq(1)');
                    const text = cell.text().trim();
                    const newText = this.newCountForText(text, 1);
                    cell.text(newText);

                    const senderCell = row.find('td:eq(3)');
                    senderCell.text(comment.adminUsername.toUpperCase() + ' (' + this.formatServerDate(comment.date) + ')');
                }
            });
        }

        private resetHeding(table: JQuery): void {
            const heading = table.find('h4')
            const textArr = heading.text().split('(');
            const text = textArr[1].trim();
            const oldCount = text.substr(0, 1);
            const newCount = parseInt(oldCount) + 1;
            const isZeroOrPlural = text.search('records') > -1 || text.search('0') > -1;
            const newText = isZeroOrPlural ? textArr[0] + '(' + newCount + text.substring(1) : textArr[0] + '(' + newCount + ' records)';
            console.log(newText);
            heading.text(newText)
        }

        private resetSerialNo(table: JQuery): void {
            const rows = table.find('tr');

            for (let i = 0; i < rows.length; i++) {
                if (i < 2) continue;
                const row = $(rows[i]);
                const snCell = row.find('td:first');
                snCell.text(i + '.');
            }
        }

        private getRowHtml(comment: IComment, paymentInfo: IPaymentInfo) {
            return `<tr data-payment-id="${comment.paymentId}">
                    <td>1.</td>
                    <td>1 unread comment for ${paymentInfo.customerGivenId}</td>
                    <td>${paymentInfo.description}</td>
                    <td>${comment.adminUsername.toUpperCase()} (${this.formatServerDate(comment.date)})</td>
                    <td><a href="/Customer/Payment?paymentId=${comment.paymentId}">Open</a></td>
                </tr>`;
        }

    }

}