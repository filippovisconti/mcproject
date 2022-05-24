﻿using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace mcproject.Models
{
    public class EventoSportivo
    {

        public int ID { get; set; }
        public string Owner { get; set; }
        public Sport Sport { get; set; }
        public City City { get; set; }
        public Difficulty Level { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Notes { get; set; }
        public string TGUsername { get; set; }
        //public Image IconName { get; set; }
        public string IconName { get; set; }
        public IList<EventoSportivo> Object { get; internal set; }

        public EventoSportivo()
        {

        }

        public override string ToString()
        {
            return Sport.Name + City + Level.Level;
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
