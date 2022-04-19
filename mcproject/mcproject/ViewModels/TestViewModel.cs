using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Web;
using mcproject.Models;
using MvvmHelpers.Commands;
using Xamarin.Forms;
namespace mcproject.ViewModels
{
    public class TestViewModel : ViewModelBase, IQueryAttributable



    {
        private string _TestSport;
        public string TestSport
        {
            get => _TestSport;
            set => SetProperty(ref _TestSport, value);
        }

        private DateTime _TestDate;
        public DateTime TestDate
        {
            get => _TestDate;
            set => SetProperty(ref _TestDate, value);
        }

        private string _TestLevel;
        public string TestLevel
        {
            get => _TestLevel;
            set => SetProperty(ref _TestLevel, value);
        }

        private string _TestTG;
        public string TestTG
        {
            get => _TestTG;
            set => SetProperty(ref _TestTG, value);
        }

        private string _TestCity;
        public string TestCity
        {
            get => _TestCity;
            set => SetProperty(ref _TestCity, value);
        }

        private string _TestNote;
        public string TestNote
        {
            get => _TestNote;
            set => SetProperty(ref _TestNote, value);
        }

       /*

       public void ApplyQueryAttributes(IDictionary<string, string> query)
       {
           throw new NotImplementedException();
       }

        */

       public void ApplyQueryAttributes(IDictionary<string, string> query)
       {
           this.TestTG = HttpUtility.UrlDecode(query["tg"]);
           this.TestSport = HttpUtility.UrlDecode(query["sport"]);
           this.TestDate = Convert.ToDateTime(HttpUtility.UrlDecode(query["data"]));
           this.TestLevel = HttpUtility.UrlDecode(query["level"]);
           this.TestCity = HttpUtility.UrlDecode(query["city"]);
           this.TestNote = HttpUtility.UrlDecode(query["note"]);
       }

       public void GetAttributes()
       {
           IDictionary<string, string> openWith = new Dictionary<string, string>();

           openWith.Add("sport", "SelectedSport");
           openWith.Add("data", "SelectedData");
           openWith.Add("level", "SelectedLevel");
           openWith.Add("tg", "SelectedTGusername");
           openWith.Add("city", "SelectedCity");
           openWith.Add("note", "SelectedNote");

           ApplyQueryAttributes(openWith);


       }

    }
}
