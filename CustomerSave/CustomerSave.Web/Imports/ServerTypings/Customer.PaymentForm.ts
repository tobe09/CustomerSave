namespace CustomerSave.Customer {
    export interface PaymentForm {
        CustomerId: Serenity.IntegerEditor;
        CustomerCustomerGivenId: Serenity.StringEditor;
        CustomerUsername: Serenity.StringEditor;
        CustomerFirstName: Serenity.StringEditor;
        CustomerLastName: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        Description: Serenity.StringEditor;
        CreatedDate: Serenity.DateEditor;
        Total: Serenity.StringEditor;
    }

    export class PaymentForm extends Serenity.PrefixedContext {
        static formKey = 'Customer.Payment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentForm.init)  {
                PaymentForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.DateEditor;

                Q.initFormType(PaymentForm, [
                    'CustomerId', w0,
                    'CustomerCustomerGivenId', w1,
                    'CustomerUsername', w1,
                    'CustomerFirstName', w1,
                    'CustomerLastName', w1,
                    'Amount', w2,
                    'Description', w1,
                    'CreatedDate', w3,
                    'Total', w1
                ]);
            }
        }
    }
}
