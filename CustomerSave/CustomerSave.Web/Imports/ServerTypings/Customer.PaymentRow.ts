namespace CustomerSave.Customer {
    export interface PaymentRow {
        PaymentId?: number;
        CustomerId?: number;
        Amount?: number;
        AmountString?: string;
        Total?: string;
        Description?: string;
        CreatedBy?: number;
        CreatedDate?: string;
        Comment?: string;
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
            AmountString = "AmountString",
            Total = "Total",
            Description = "Description",
            CreatedBy = "CreatedBy",
            CreatedDate = "CreatedDate",
            Comment = "Comment",
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
