using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp.DAOMock1.BO
{
    public class Producer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
