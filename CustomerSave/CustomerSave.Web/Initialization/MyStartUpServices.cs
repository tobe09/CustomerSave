using CustomerSave.Common;
using CustomerSave.Customer.MakePayment;
using CustomerSave.Hubs;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyStartUpServices
    {
        public static IServiceCollection AddCustomerSaveServices(this IServiceCollection services)
        {
            //add services (and data providers)
            services.AddTransient<IMakePaymentService, MakePaymentService>();
            services.AddTransient<IMakePaymentDataAccess, MakePaymentDataAccess>();

            services.AddTransient<ICommentHubService, CommentHubService>();
            services.AddTransient<ICommentHubDataAccess, CommentHubDataAccess>();
                        
            services.AddScoped(provider => DatabaseHelper.GetConnection());     //my database connection

            return services;
        }

        public static IServiceCollection AddCustomerSaveServices(this IServiceCollection services, Action<IServiceCollection> action)
        {
            services = AddCustomerSaveServices(services);
            action(services);

            return services;
        }
    }
}
