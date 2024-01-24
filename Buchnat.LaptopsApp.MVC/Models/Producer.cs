using Buchnat.LaptopsApp.Core;
using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp.MVC.Models
{
    public class Producer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
