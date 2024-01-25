using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopsApp.Web.Models
{
    [Table("Laptops")]
    public class Laptop : ILaptop
    {
        [Key]
        public Guid Id { get; set; }

        public IProducer? Producer { get; set; }

        public string Model { get; set; }

        public ProcessorType Processor { get; set; }

        public int RAM { get; set; }

        public int StorageInGB { get; set; }

        [ForeignKey("Producer.Id")]
        public Guid ProducerId { get; set; }
    }
}
