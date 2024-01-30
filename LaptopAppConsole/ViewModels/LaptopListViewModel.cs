using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.ViewModels
{
    public class LaptopListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<LaptopViewModel> Laptops { get; set; } = new ObservableCollection<LaptopViewModel>();

        public void RefreshList(IEnumerable<ILaptop> laptops)
        {
            Laptops.Clear();

            foreach (var laptop in laptops)
            {
                Laptops.Add(new LaptopViewModel(laptop));
            }

            RaisePropertyChanged(nameof(Laptops));
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
