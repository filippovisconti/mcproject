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

        public EventoSportivo(string owner, string sport, string city, string level, DateTime dateAndTime, string notes, string tGUsername)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Sport = sport ?? throw new ArgumentNullException(nameof(sport));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Level = level ?? throw new ArgumentNullException(nameof(level));
            DateAndTime = dateAndTime;
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            TGUsername = tGUsername ?? throw new ArgumentNullException(nameof(tGUsername));
        }

        public EventoSportivo()
        {

        }

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
