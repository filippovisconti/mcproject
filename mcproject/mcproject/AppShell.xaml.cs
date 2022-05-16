using System;
using System.Collections.Generic;
using mcproject.ViewModels;
using mcproject.Views;
using Xamarin.Forms;

namespace mcproject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
            Routing.RegisterRoute(nameof(JoinPage), typeof(JoinPage));
            Routing.RegisterRoute(nameof(ManagePage), typeof(ManagePage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));  
            Routing.RegisterRoute(nameof(LookForPage), typeof(LookForPage));
            Routing.RegisterRoute(nameof(ModifyEventPage), typeof(ModifyEventPage));
            Routing.RegisterRoute(nameof(ConfirmCreationPage), typeof(ConfirmCreationPage));

 Routing.RegisterRoute(nameof(SumUpPage), typeof(SumUpPage));
        }

    }
}
