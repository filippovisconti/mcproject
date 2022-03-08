using System;
using SQLite;
using Xamarin.Forms;

namespace mcproject.Models
{
    public class EventoSportivo
    {
        public EventoSportivo()
        {
           
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Owner { get; set; }
        public string Sport { get; set; }
        public string City { get; set; }
        public string Level { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Notes { get; set; }
        public string TGUsername { get; set; }
        public Image Icon { get; set; }
    }
}
