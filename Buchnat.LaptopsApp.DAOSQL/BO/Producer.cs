using Buchnat.LaptopsApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Buchnat.LaptopsApp.DAOSQL
{
    public class ProducerDBSQL: IProducer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IProducer ToIProducer()
        {
            return new Producer()
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }

    class Producer : IProducer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }


}
