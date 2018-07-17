using CustomerSave.Customer.Entities;
using CustomerSave.Common;
using Dapper;
using System;

namespace CustomerSave.Customer.MakePayment
{
    public class MakePaymentService : IMakePaymentService
    {
        public MakePaymentViewModel GetCustomerByGivenId(string customerGivenId)
        {
            var connection = DatabaseHelper.GetConnection();
            string query = "select * from [dbo].Customer where UPPER(CustomerGivenid) = @customerGivenId";
            return connection.QueryFirstOrDefault<MakePaymentViewModel>(query, new { customerGivenId = customerGivenId?.ToUpper() });
        }

        public MakePaymentViewModel GetCustomerByUsername(string username)
        {
            var connection = DatabaseHelper.GetConnection();
            string query = "select * from [dbo].Customer where UPPER(Username) = @username";
            return connection.QueryFirstOrDefault<MakePaymentViewModel>(query, new { username = username?.ToUpper() });
        }

        public string PostPayment(MakePaymentViewModel model, int createdBy)
        {
            try
            {
                model.Validate();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            var connection = DatabaseHelper.GetConnection();
            string selectQuery = "select * from [dbo].Customer where CustomerGivenId = @CustomerGivenId";
            int customerId = (int)connection.QueryFirst<CustomerRow>(selectQuery, new { model.CustomerGivenId }).CustomerId;

            string insertQuery = "insert into [dbo].Payment values(@CustomerId, @Amount, @Description, @CreatedBy, @CreatedDate)";  
            int status = connection.Execute(insertQuery, new { customerId, model.Amount, model.Description, createdBy, CreatedDate = DateTime.Now });

            return status == 0 ? "Error occured while saving payment" : null;
        }
    }
}
