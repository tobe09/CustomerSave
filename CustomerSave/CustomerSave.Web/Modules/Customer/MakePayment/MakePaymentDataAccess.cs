using CustomerSave.Customer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CustomerSave.Customer.MakePayment
{
    public interface IMakePaymentDataAccess
    {
        MakePaymentViewModel GetCustomerByGivenId(string customerGivenId);
        MakePaymentViewModel GetCustomerByUsername(string username);
        int GetCustomerIdFromGivenId(string customerGivenId);
        int InsertPaymentRecord(int customerId, decimal amount, string description, int createdBy);
        IEnumerable<int> GetAllUserIds();
        int InsertCommentTracksForPayment(int paymentId, int viewingAdminId);
        int GetInsertedPaymentId();
    }

    public class MakePaymentDataAccess : IMakePaymentDataAccess
    {
        private IDbConnection connection;

        public MakePaymentDataAccess(IDbConnection connection)
        {
            this.connection = connection;
        }

        public MakePaymentViewModel GetCustomerByGivenId(string customerGivenId)
        {
            string query = "select * from [dbo].Customer where UPPER(CustomerGivenid) = @customerGivenId";
            return connection.QueryFirstOrDefault<MakePaymentViewModel>(query, new { customerGivenId = customerGivenId?.ToUpper() });
        }

        public MakePaymentViewModel GetCustomerByUsername(string username)
        {
            string query = "select * from [dbo].Customer where UPPER(Username) = @username";
            return connection.QueryFirstOrDefault<MakePaymentViewModel>(query, new { username = username?.ToUpper() });
        }

        public int GetCustomerIdFromGivenId(string customerGivenId)
        {
            string query = "select * from [dbo].Customer where CustomerGivenId = @customerGivenId";
            int customerId = (int)connection.QueryFirst<CustomerRow>(query, new { customerGivenId }).CustomerId;

            return customerId;
        }

        public int InsertPaymentRecord(int customerId, decimal amount, string description, int createdBy)
        {
            string insertQuery = "insert into [dbo].Payment values(@CustomerId, @Amount, @Description, @CreatedBy, @CreatedDate)";
            int status = connection.Execute(insertQuery, new { customerId, amount, description, createdBy, CreatedDate = DateTime.Now });

            return status;
        }

        public int GetInsertedPaymentId()
        {
            string query = "SELECT IDENT_CURRENT ('[dbo].Payment') AS Current_Identity; ";
            var value = connection.QueryFirst(query);

            return (int)value.Current_Identity;
        }

        public IEnumerable<int> GetAllUserIds()
        {
            string query = "select UserId from [dbo].Users";
            return connection.Query<int>(query);
        }

        public int InsertCommentTracksForPayment(int paymentId, int viewingAdminId)
        {
            string query = "insert into [dbo].CommentTracker values(@paymentId, @viewingAdminId, @lastViewDate)";
            return connection.Execute(query, new { paymentId, viewingAdminId, lastViewDate = DateTime.Now });
        }
    }
}
