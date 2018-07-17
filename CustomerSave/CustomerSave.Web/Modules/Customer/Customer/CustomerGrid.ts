
namespace CustomerSave.Customer {

    @Serenity.Decorators.registerClass()
    export class CustomerGrid extends Serenity.EntityGrid<CustomerRow, any> {
        protected getColumnsKey() { return 'Customer.Customer'; }
        protected getDialogType() { return CustomerDialog; }
        protected getIdProperty() { return CustomerRow.idProperty; }
        protected getLocalTextPrefix() { return CustomerRow.localTextPrefix; }
        protected getService() { return CustomerService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getQuickSearchFields(): Serenity.QuickSearchField[] {
            return [
                { name: "", title: "All" },
                { name: CustomerRow.Fields.CustomerGivenId, title: "Customer Id" },
                { name: CustomerRow.Fields.Username, title: "Username" },
                { name: CustomerRow.Fields.FullName, title: "Full Name" }
            ];
        }
    }
}