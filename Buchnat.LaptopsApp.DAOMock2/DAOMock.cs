using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp.DAOMock2
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<ILaptop> laptops;
        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id = Guid.NewGuid(), Name = "Huawei"},
                new BO.Producer() {Id = Guid.NewGuid(), Name = "LG"}
            };
            laptops = new List<ILaptop>()
            {
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[0], Model =  "MateBook D 16", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512 },
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[0], Model = "MateBook 16", Processor = Core.ProcessorType.AMD, RAM = 16, StorageInGB = 512 },
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[1], Model = "Gram 2023", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[1], Model = "Gram 2021", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512}
            };
        }



        public ILaptop CreateNewLaptop()
        {
            return new BO.Laptop();
        }

        public ILaptop CreateNewLaptop(ILaptop laptop)
        {
            if (laptop == null)
                throw new ArgumentNullException(nameof(laptop));

            laptops.Add(laptop);
            return laptop;
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IProducer CreateNewProducer(IProducer producer)
        {
            if (producer == null)
                throw new ArgumentNullException(nameof(producer));

            producers.Add(producer);
            return producer;
        }

        public IEnumerable<ILaptop> GetAllLaptops()
        {
            return laptops;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }

        public ILaptop GetLaptop(Guid id)
        {
            return laptops.FirstOrDefault(l => l.Id == id);
        }

        public IProducer GetProducer(Guid id)
        {
            return producers.FirstOrDefault(p => p.Id == id);
        }

        public void RemoveLaptop(Guid id)
        {
            laptops.RemoveAll(l => l.Id == id);
        }

        public void RemoveProducer(Guid id)
        {
            producers.RemoveAll(p => p.Id == id);
        }

        public void UpdateLaptop(ILaptop laptop)
        {
            var existing = GetLaptop(laptop.Id);
            if (existing != null)
            {
                laptops.Remove(existing);
            }
            laptops.Add(laptop);
        }

        public void UpdateProducer(IProducer producer)
        {
            var existing = GetProducer(producer.Id);
            if (existing != null)
            {
                producers.Remove(existing);
            }
            producers.Add(producer);
        }
        public IProducer GetProducer(string name)
        {
            return (IProducer)producers.Where(producer => producer.Name.Equals(name)).FirstOrDefault();
        }
    }
}