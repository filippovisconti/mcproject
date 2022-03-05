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
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
            Routing.RegisterRoute(nameof(JoinPage), typeof(JoinPage));
            Routing.RegisterRoute(nameof(ManagePage), typeof(ManagePage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));  // FIXME to be removed once completed

        }

    }
}
