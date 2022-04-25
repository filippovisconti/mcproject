using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace mcproject.Models
{
    public class Sport : ObservableObject
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


}
