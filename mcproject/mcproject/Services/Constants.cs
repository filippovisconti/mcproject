using System;
using System.Collections.ObjectModel;

namespace mcproject.Services
{
    public static class Constants
    {
        public static ObservableCollection<string> Sport = new ObservableCollection<string>();
        public static ObservableCollection<string> Livello = new ObservableCollection<string>();
        public static ObservableCollection<string> City = new ObservableCollection<string>();

        static Constants()
        {
            Sport.Add("Calcetto");
            Sport.Add("Pallavolo");
            Sport.Add("Beach volley");
            Sport.Add("Golf");
            Livello.Add("Principiante");
            Livello.Add("Medio");
            Livello.Add("Avanzato");
            City.Add("Roma");
            City.Add("Milano");
        }
    }
}
