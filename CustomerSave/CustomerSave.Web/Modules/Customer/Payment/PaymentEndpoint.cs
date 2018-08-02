
namespace CustomerSave.Customer.Endpoints
{
    using Microsoft.AspNetCore.Mvc;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using MyRepository = Repositories.PaymentRepository;
    using MyRow = Entities.PaymentRow;

    [Route("Services/Customer/Payment/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class PaymentController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            throw new ValidationError("Cannot create record from here. Go to Post payment");
            //return new MyRepository().Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            throw new ValidationError("Record cannot be updated (Delete and post correct values).");
            //return new MyRepository().Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            //throw new ValidationError("Cannot delete record.");
            return new MyRepository().Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }
    }
}
