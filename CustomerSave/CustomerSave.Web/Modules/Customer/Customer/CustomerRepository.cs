
namespace CustomerSave.Customer.Repositories
{
    using CustomerSave.Membership;
    using Microsoft.AspNetCore.Mvc;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.CustomerRow;

    public class CustomerRepository
    {
        private Controller controller;

        public CustomerRepository() : base() { }
        public CustomerRepository(Controller controller) : base() { this.controller = controller; }

        private static MyRow.RowFields Fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        { 
            return new MySaveHandler(controller).Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler(controller).Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }


        private class MySaveHandler : SaveRequestHandler<MyRow>
        {
            private Controller controller;
            
            public MySaveHandler(Controller controller) : base() { this.controller = controller; }

            protected override void ValidateRequest()
            {
                var customer = Request.Entity;
                if (IsCreate)
                {
                    customer.CustomerGivenId = GetNewCustomerId();
                    customer.CreatedBy = User.GetCurrentUser(controller.Request.HttpContext).UserId;
                    customer.CreatedDate = DateTime.Now;
                }
                else  //IsUpdate
                {
                    customer.ModifiedBy = User.GetCurrentUser(controller.Request.HttpContext).UserId;
                    customer.ModifiedDate = DateTime.Now;
                }
                customer.Validate();

                base.ValidateRequest();
            }

            private string GetNewCustomerId()
            {
                string preId = "CUSTOMER";

                var listResponse = new MyListHandler().Process(Connection, 
                                       new ListRequest { Sort = new[] { new SortBy { Field = "CustomerId", Descending = true } } });
                var entity = listResponse.Entities.FirstOrDefault();

                if (entity == null) return preId + "0001";

                int newId = (int)entity.CustomerId + 1;
                if (newId < 10) return preId + "000" + newId;
                else if (newId < 100) return preId + "00" + newId;
                else if (newId < 10) return preId + "0" + newId;
                else return preId + newId;
            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            protected override void ValidateRequest()
            {
                var count = new PaymentRepository().List(Connection, new ListRequest()).Entities.Where(p => p.CustomerId == (long)Request.EntityId).Count();
                if (count > 0) throw new ValidationError("Patient has an active payment");

                base.ValidateRequest();
            }
        }

        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }

        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}