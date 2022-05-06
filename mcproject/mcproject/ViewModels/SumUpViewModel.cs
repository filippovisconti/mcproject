using System;
using System.Collections.Generic;
using System.Web;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class SumUpViewModel : ViewModelBase, IQueryAttributable
    {
        public SumUpViewModel()
        {
        }


        private string _ID;
        public string ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }



        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            this.ID = HttpUtility.UrlDecode(query["ID"]);
        }

        public void GetAttributes()
        {
            IDictionary<string, string> openWith = new Dictionary<string, string>();

            openWith.Add("ID", "SelectedEvent.ID");

            ApplyQueryAttributes(openWith);

        }

    }
}
