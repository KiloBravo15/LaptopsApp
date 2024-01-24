using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.DAOMock2.BO
{
    public class Laptop : ILaptop
    {
        public int Id {  get; set; }
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public ProcessorType Processor { get; set; }
        public int RAM { get; set; }
        public int StorageInGB { get; set; }
    }
}
