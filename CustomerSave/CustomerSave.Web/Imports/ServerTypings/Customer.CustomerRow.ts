namespace CustomerSave.Customer {
    export interface CustomerRow {
        CustomerId?: number;
        CustomerGivenId?: string;
        Username?: string;
        FirstName?: string;
        LastName?: string;
        MiddleName?: string;
        FullName?: string;
        Email?: string;
        PhoneNo?: number;
        PhoneNo2?: number;
        HomeAddress?: string;
        CreatedBy?: number;
        CreatedDate?: string;
        ModifiedBy?: number;
        ModifiedDate?: string;
    }

    export namespace CustomerRow {
        export const idProperty = 'CustomerId';
        export const nameProperty = 'CustomerGivenId';
        export const localTextPrefix = 'Customer.Customer';

        export declare const enum Fields {
            CustomerId = "CustomerId",
            CustomerGivenId = "CustomerGivenId",
            Username = "Username",
            FirstName = "FirstName",
            LastName = "LastName",
            MiddleName = "MiddleName",
            FullName = "FullName",
            Email = "Email",
            PhoneNo = "PhoneNo",
            PhoneNo2 = "PhoneNo2",
            HomeAddress = "HomeAddress",
            CreatedBy = "CreatedBy",
            CreatedDate = "CreatedDate",
            ModifiedBy = "ModifiedBy",
            ModifiedDate = "ModifiedDate"
        }
    }
}
