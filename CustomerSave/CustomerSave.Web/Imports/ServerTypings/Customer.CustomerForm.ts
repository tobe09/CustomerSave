namespace CustomerSave.Customer {
    export interface CustomerForm {
        Username: Serenity.StringEditor;
        FirstName: Serenity.StringEditor;
        LastName: Serenity.StringEditor;
        MiddleName: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        PhoneNo: Serenity.StringEditor;
        PhoneNo2: Serenity.StringEditor;
        HomeAddress: Serenity.StringEditor;
    }

    export class CustomerForm extends Serenity.PrefixedContext {
        static formKey = 'Customer.Customer';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!CustomerForm.init)  {
                CustomerForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(CustomerForm, [
                    'Username', w0,
                    'FirstName', w0,
                    'LastName', w0,
                    'MiddleName', w0,
                    'Email', w0,
                    'PhoneNo', w0,
                    'PhoneNo2', w0,
                    'HomeAddress', w0
                ]);
            }
        }
    }
}
