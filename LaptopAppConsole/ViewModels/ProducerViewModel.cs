using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.ViewModels
{
    public class ProducerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private IProducer producer;

        public ProducerViewModel(IProducer producer)
        {
            this.producer = producer;
        }

        public Guid ProducerGUID
        {
            get => producer.Id;
            set
            {
                producer.Id = value;
                RaisePropertyChanged(nameof(ProducerGUID));
            }
        }

        public string ProducerName
        {
            get => producer.Name;
            set
            {
                producer.Name = value;
                RaisePropertyChanged(nameof(ProducerName));
            }
        }

        public string ProducerDescription
        {
            get => producer.Description;
            set
            {
                producer.Description = value;
                RaisePropertyChanged(nameof(ProducerDescription));
            }
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
