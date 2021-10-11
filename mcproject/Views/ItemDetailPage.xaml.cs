using System.ComponentModel;
using Xamarin.Forms;
using mcproject.ViewModels;

namespace mcproject.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
