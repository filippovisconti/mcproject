using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace mcproject.ViewModels
{
    public class JoinViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Sport> Sport {get; set; }
        public ObservableRangeCollection<Grouping<string, Sport>> SportGroups { get; }
        
        public JoinViewModel()
        {
            Sport = new ObservableRangeCollection<Sport>();
        }

    }
}