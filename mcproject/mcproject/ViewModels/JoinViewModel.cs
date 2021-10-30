using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class JoinViewModel : ContentPage
    {
        public JoinViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }

        public DateTimeOffset MaxDate => new DateTime(2100, 12, 31);
    }
}