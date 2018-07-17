
namespace CustomerSave.Customer {

    @Serenity.Decorators.registerClass()
    export class PaymentDialog extends Serenity.EntityDialog<PaymentRow, any> {
        protected getFormKey() { return PaymentForm.formKey; }
        protected getIdProperty() { return PaymentRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentRow.localTextPrefix; }
        protected getNameProperty() { return PaymentRow.nameProperty; }
        protected getService() { return PaymentService.baseUrl; }

        protected form = new PaymentForm(this.idPrefix);

    }
}