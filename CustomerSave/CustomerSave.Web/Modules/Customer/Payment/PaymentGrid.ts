
namespace CustomerSave.Customer {

    @Serenity.Decorators.registerClass()
    export class PaymentGrid extends Serenity.EntityGrid<PaymentRow, any> {
        protected getColumnsKey() { return 'Customer.Payment'; }
        protected getDialogType() { return PaymentDialog; }
        protected getIdProperty() { return PaymentRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentRow.localTextPrefix; }
        protected getService() { return PaymentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}