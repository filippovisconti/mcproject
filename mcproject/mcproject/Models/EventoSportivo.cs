using System;
using SQLite;
using Xamarin.Forms;

namespace mcproject.Models
{
    public class EventoSportivo
    {

        public int ID { get; set; }
        public string Owner { get; set; }
        public string Sport { get; set; }
        public string City { get; set; }
        public string Level { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Notes { get; set; }
        public string TGUsername { get; set; }
        public Image Icon { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                EventoSportivo p = (EventoSportivo)obj;
                return (this.ID == p.ID);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
