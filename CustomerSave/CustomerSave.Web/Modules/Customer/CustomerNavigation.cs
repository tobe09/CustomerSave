using Serenity.Navigation;
using MyPages = CustomerSave.Customer.Pages;

[assembly: NavigationMenu(9000, "Customer Tasks", icon: "fa-user-plus")]
[assembly: NavigationLink(9000, "Customer Tasks/Manage Customers", typeof(MyPages.CustomerController), icon: "fa-users")]
[assembly: NavigationLink(9000, "Customer Tasks/Post Payment", typeof(MyPages.MakePaymentController), icon: "fa-user")]
[assembly: NavigationLink(9000, "Customer Tasks/Manage Payments", typeof(MyPages.PaymentController), icon: "fa-users")]