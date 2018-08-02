///<reference path="../node_modules/@aspnet/signalr/dist/esm/index.d.ts" />

namespace CustomerSave {

    export class General {

        public static Constants = {
            Sitename: 'CustomerSave',
            HubAddress: "/CommentHub"
        };

        public getCommentHubConnection() {
            return new signalR.HubConnectionBuilder()
                .withUrl(General.Constants.HubAddress)
                .configureLogging(signalR.LogLevel.Information)
                .build();
        }

        public showErrorMsg(msg = "Network Error Has Occured", msgSpan = $('.error-div')): void {
            msgSpan.text(msg);
            msgSpan.removeClass('text-success');
            msgSpan.addClass('text-danger');
        }

        public showSuccessMsg(msg = "Customer Found", msgSpan = $('.error-div')): void {
            msgSpan.text(msg);
            msgSpan.removeClass('text-danger');
            msgSpan.addClass('text-success');
        }

        public networkApi(url: string, data: object, type = "GET"): PromiseLike<any> {
            return new Promise((resolve, reject) => {
                $.ajax({
                    dataType: "json",
                    url,
                    type,
                    data,
                    success: result => resolve(result),
                    error: err => reject(err)
                })
            });
        }

        public formatServerDate(date: string): string {
            const dateArr = date.split('-');
            const year = parseInt(dateArr[0]);
            const month = parseInt(dateArr[1]);
            const day = parseInt(dateArr[2].substr(0, 2));

            return `${month}/${day}/${year}`;
        }

        public newCountForText(text: string, increment: number, valSingular = 'comment', valPlural = 'comments'): string {
            const oldCount = text.substr(0, 1);
            const newCount = parseInt(oldCount) + increment;
            const isPlural = text.search(valPlural) > -1;
            const newText = isPlural ? newCount + text.substring(1) : newCount + text.substring(1).replace(valSingular, valPlural);

            return newText;
        }

    }

}