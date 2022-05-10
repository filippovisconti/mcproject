using System.Collections.Generic;
using mcproject.Models;

namespace mcproject.Services
{
    public static class Constants
    {

        public static IList<City> cities = new List<City>();

        static Constants()
        {
            cities.Add(new City()
            {
                Name = "Roma"
            });
            cities.Add(new City()
            {
                Name = "Milano"
            });
            cities.Add(new City()
            {
                Name = "Torino"
            });
            cities.Add(new City()
            {
                Name = "Ancona"
            });
        }
    }
}
