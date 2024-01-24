using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp.MVC.Models
{
    public class Laptop : ILaptop
    {
        public int Id { get; set; }
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public ProcessorType Processor { get; set; }
        public int RAM { get; set; }
        public int StorageInGB { get; set; }
    }
}
