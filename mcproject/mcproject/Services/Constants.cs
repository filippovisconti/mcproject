using System;
using System.Collections.ObjectModel;

namespace mcproject.Services
{
    public static class Constants
    {
        public static ObservableCollection<string> Sport = new();
        public static ObservableCollection<string> Livello = new();
        public static ObservableCollection<string> City = new();

        static Constants()
        {
            Sport.Add("Calcio");
            Sport.Add("Calcetto");
            Sport.Add("Calciotto");
            Sport.Add("Pallavolo");
            Sport.Add("Beach volley");
            Sport.Add("Golf");
            Sport.Add("Tennis");
            Sport.Add("Padel");
            Livello.Add("Principiante");
            Livello.Add("Medio");
            Livello.Add("Avanzato");
            City.Add("Roma");
            City.Add("Milano");
        }
    }
}
