using Serenity.Services;
using System.Collections.Generic;

namespace CustomerSave.Customer.MakePayment
{
    public class MakePaymentService : IMakePaymentService
    {
        private IMakePaymentDataAccess makePaymentDao;

        public MakePaymentService(IMakePaymentDataAccess makePaymentDao)
        {
            this.makePaymentDao = makePaymentDao;
        }

        public MakePaymentViewModel GetCustomerByGivenId(string customerGivenId)
        {
            return makePaymentDao.GetCustomerByGivenId(customerGivenId);
        }

        public MakePaymentViewModel GetCustomerByUsername(string username)
        {
            return makePaymentDao.GetCustomerByUsername(username);
        }

        public string PostPayment(MakePaymentViewModel model, int createdBy)
        {
            try { model.Validate(); }
            catch (ValidationError ex) { return ex.Message; }

            int customerId = makePaymentDao.GetCustomerIdFromGivenId(model.CustomerGivenId);

            int status = makePaymentDao.InsertPaymentRecord(customerId, model.Amount, model.Description, createdBy);
            int paymentId = makePaymentDao.GetInsertedPaymentId();

            IEnumerable<int> userIds = makePaymentDao.GetAllUserIds();
            foreach(int userId in userIds)
            {
                makePaymentDao.InsertCommentTracksForPayment(paymentId, userId);        //initialize record for comment management and tracking
            }
            
            return status == 0 ? "Error occured while saving payment" : null;
        }
    }
}
