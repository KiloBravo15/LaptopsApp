using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.DAOSQL
{
    public class LaptopDBSQL: ILaptop
    {
        [Key]
        public Guid Id { get; set; }
        public string ProducerId { get; set; } 
        public string Model { get; set; }
        public ProcessorType Processor { get; set; }
        public int RAM { get; set; }
        public int StorageInGB { get; set; }
        [NotMapped]
        public IProducer Producer { get; set; }

        public ILaptop ToILaptop(List<ProducerDBSQL> producers)
        {
            var producer = producers.SingleOrDefault(p => p.Id.Equals(ProducerId));
            return new Laptop()
            {
                Id = Id,
                Producer = producer?.ToIProducer(),
                Model = Model,
                Processor = Processor,
                RAM = RAM,
                StorageInGB = StorageInGB
            };
        }
    }

    public class Laptop : ILaptop
    {
        public Guid Id { get; set; }
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public ProcessorType Processor { get; set; }
        public int RAM { get; set; }
        public int StorageInGB { get; set; }
    }
}
