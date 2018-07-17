namespace CustomerSave.Customer {
    export interface PaymentRow {
        PaymentId?: number;
        CustomerId?: number;
        Amount?: number;
        Description?: string;
        CreatedBy?: number;
        CreatedDate?: string;
        CustomerCustomerGivenId?: string;
        CustomerUsername?: string;
        CustomerFirstName?: string;
        CustomerLastName?: string;
        CustomerMiddleName?: string;
        CustomerFullName?: string;
        CustomerEmail?: string;
        CustomerPhoneNo?: number;
        CustomerPhoneNo2?: number;
        CustomerHomeAddress?: string;
        CustomerCreatedBy?: number;
        CustomerCreatedDate?: string;
        CustomerModifiedBy?: number;
        CustomerModifiedDate?: string;
    }

    export namespace PaymentRow {
        export const idProperty = 'PaymentId';
        export const nameProperty = 'Description';
        export const localTextPrefix = 'Customer.Payment';

        export declare const enum Fields {
            PaymentId = "PaymentId",
            CustomerId = "CustomerId",
            Amount = "Amount",
            Description = "Description",
            CreatedBy = "CreatedBy",
            CreatedDate = "CreatedDate",
            CustomerCustomerGivenId = "CustomerCustomerGivenId",
            CustomerUsername = "CustomerUsername",
            CustomerFirstName = "CustomerFirstName",
            CustomerLastName = "CustomerLastName",
            CustomerMiddleName = "CustomerMiddleName",
            CustomerFullName = "CustomerFullName",
            CustomerEmail = "CustomerEmail",
            CustomerPhoneNo = "CustomerPhoneNo",
            CustomerPhoneNo2 = "CustomerPhoneNo2",
            CustomerHomeAddress = "CustomerHomeAddress",
            CustomerCreatedBy = "CustomerCreatedBy",
            CustomerCreatedDate = "CustomerCreatedDate",
            CustomerModifiedBy = "CustomerModifiedBy",
            CustomerModifiedDate = "CustomerModifiedDate"
        }
    }
}
