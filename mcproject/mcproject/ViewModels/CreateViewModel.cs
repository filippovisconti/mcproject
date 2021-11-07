using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Amazon.RDS.Model;
using mcproject.Models;

namespace mcproject.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        public CreateViewModel()
        {


        }

        public ObservableCollection<string> CreateSport
        {
            get => Services.Constants.Sport;
        }

        private string _SelectedSport;
        public string SelectedSport
        {
            get => _SelectedSport;
            set => SetProperty(ref _SelectedSport, value);
        }

        /* public void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
         {

             var picker = (Picker)sender;
             int selectedIndex = picker.SelectedIndex;

             if (selectedIndex != -1)
             {
                 SelectedSport = (string)picker.ItemsSource[selectedIndex];
             }
         }*/


        private DateTime _SelectedData;
        public DateTime SelectedData
        {
            get => _SelectedData;
            set => SetProperty(ref _SelectedData, value);
        }


        public EventoSportivo CreateEvento;
        public void Create()
        {
            CreateEvento.Sport = SelectedSport;
            CreateEvento.DateAndTime = SelectedData;

        }

       








    }

}
