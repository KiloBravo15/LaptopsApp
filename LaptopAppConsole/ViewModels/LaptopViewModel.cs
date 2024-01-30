using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.ViewModels
{
    public class LaptopViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ILaptop laptop;

        public LaptopViewModel(ILaptop laptop)
        {
            this.laptop = laptop;
        }

        public Guid LaptopGUID
        {
            get => laptop.Id;
            set
            {
                laptop.Id = value;
                RaisePropertyChanged(nameof(LaptopGUID));
            }
        }

        public IProducer LaptopProducer
        {
            get => laptop.Producer;
            set
            {
                laptop.Producer = value;
                RaisePropertyChanged(nameof(LaptopProducer));
            }
        }

        public string LaptopModel
        {
            get => laptop.Model;
            set
            {
                laptop.Model = value;
                RaisePropertyChanged(nameof(LaptopModel));
            }
        }

        public Core.ProcessorType LaptopProcessor
        {
            get => laptop.Processor;
            set
            {
                laptop.Processor = value;
                RaisePropertyChanged(nameof(LaptopProcessor));
            }
        }

        public int LaptopRAM
        {
            get => laptop.RAM;
            set
            {
                laptop.RAM = value;
                RaisePropertyChanged(nameof(LaptopRAM));
            }
        }

        public int LaptopStorageInGB
        {
            get => laptop.StorageInGB;
            set
            {
                laptop.StorageInGB = value;
                RaisePropertyChanged(nameof(LaptopStorageInGB));
            }
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
