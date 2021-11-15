using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mcproject.Models;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace mcproject.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {

        public AsyncCommand CreateCommand { get; }
        public CreateViewModel()
        {
            Title = "Create a new event";
            CreateCommand = new AsyncCommand(CreateMethod);
        }

        private async Task CreateMethod()
        {

            await Shell.Current.GoToAsync("CreatePage");
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

        public ObservableCollection<string> CreateLevel
        {
            get => Services.Constants.Livello;
        }


        private string _SelectedLevel;
        public string SelectedLevel
        {
            get => _SelectedLevel;
            set => SetProperty(ref _SelectedLevel, value);
        }


        private string _SelectedTGusername;
        public string SelectedTGusername
        {
            get => _SelectedTGusername;
            set => SetProperty(ref _SelectedTGusername, value);
        }

      

        private string _SelectedNote;
        public string SelectedNote
        {
            get => _SelectedNote;
            set => SetProperty(ref _SelectedNote, value);
        }


        public EventoSportivo CreateEvento;
        public void Create()
        {
            CreateEvento.Sport = SelectedSport;
            CreateEvento.DateAndTime = SelectedData;
            CreateEvento.Level = SelectedLevel;
            CreateEvento.TGUsername = SelectedTGusername;
            CreateEvento.Notes = SelectedNote;

        }

       








    }

}
