using Buchnat.LaptopsApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.Interfaces
{
    public interface ILaptop
    {
        int Id { get; set; }
        IProducer Producer { get; set; }
        string Model { get; set; }
        ProcessorType Processor { get; set; }
        int RAM { get; set; }
        int StorageInGB { get; set; }
    }

}

