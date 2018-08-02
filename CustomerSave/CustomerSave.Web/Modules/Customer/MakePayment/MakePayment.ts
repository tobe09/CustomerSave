
namespace CustomerSave.Customer {

    export class MakePayments extends CustomerSave.General {

        initializePage(): void {
            $(() => {
                $('#CustomerGivenId').keyup(e => this.checkByCustomerGivenId(e));
                $('#Username').keyup(e => this.checkByUsername(e));
            });
        }

        checkByCustomerGivenId(e: JQueryKeyEventObject): void {
            const customerGivenId = $(e.currentTarget).val();
            this.networkApi("/Customer/GetCustomerByGivenId", { customerGivenId }).then((result: ICustomerData) => {
                this.displayInfo(result, 'CustomerGivenId');
            },
                err => this.showErrorMsg());
        }

        checkByUsername(e: JQueryKeyEventObject): void {
            const username = $(e.currentTarget).val();
            this.networkApi("/Customer/GetCustomerByUsername", { username }).then((result: ICustomerData) => {
                this.displayInfo(result, 'Username');
            },
                err => this.showErrorMsg());
        }

        private displayInfo(result: ICustomerData, type: string): void {
            if (result === null) {
                if (type === 'CustomerGivenId') {
                    $('#Username').val('');
                    this.showErrorMsg('No Matching Customer For Id');
                }
                else if (type === 'Username') {
                    $('#CustomerGivenId').val('');
                    this.showErrorMsg('No Matching Customer For Username');
                }
                $('#FirstName').val('');
                $('#LastName').val('');
                $('#submitBtn').prop('disabled', true);
                return;
            }
            else {
                this.setValues(result);
            }
        }

        private setValues(result: ICustomerData): void {
            $('#CustomerGivenId').val(result.CustomerGivenId);
            $('#Username').val(result.Username);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#submitBtn').prop('disabled', false);
            this.showSuccessMsg();
        }
    }

    interface ICustomerData {
        CustomerGivenId: string,
        Username: string,
        FirstName: string,
        LastName: string,
    }
}

