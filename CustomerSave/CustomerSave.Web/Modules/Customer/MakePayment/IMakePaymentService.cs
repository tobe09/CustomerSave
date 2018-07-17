
namespace CustomerSave.Customer.MakePayment
{
    public interface IMakePaymentService
    {
        MakePaymentViewModel GetCustomerByGivenId(string customerGivenId);
        MakePaymentViewModel GetCustomerByUsername(string username);
        string PostPayment(MakePaymentViewModel model, int createdBy);
    }
}
