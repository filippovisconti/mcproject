using System;
using System.Collections.ObjectModel;

namespace mcproject.Services
{
    public static class Constants
    {
        public static ObservableCollection<string> Sport = new ObservableCollection<string>();
        public static ObservableCollection<string> Livello = new ObservableCollection<string>();

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
        }
    }
}
