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
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
