using Buchnat.LaptopsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<ILaptop> laptops;
        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id = Guid.NewGuid(), Name = "Lenovo"},
                new BO.Producer() {Id = Guid.NewGuid(), Name = "Dell"},
                new BO.Producer() {Id = Guid.NewGuid(), Name = "HP"},
                new BO.Producer() {Id = Guid.NewGuid(), Name = "Apple"}
            };
            laptops = new List<ILaptop>()
            {
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[0], Model =  "IdeaPad Slim 3", Processor = Core.ProcessorType.Intel, RAM = 8, StorageInGB = 512 },
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[0], Model = "Legion Slim 5", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512 },
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[1], Model = " Inspiron 14 Plus", Processor = Core.ProcessorType.Intel, RAM = 32, StorageInGB = 1000},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[1], Model = " Alienware x17", Processor = Core.ProcessorType.Intel, RAM = 64, StorageInGB = 1000},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[2], Model = " Envy x360", Processor = Core.ProcessorType.AMD, RAM = 16, StorageInGB = 512},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[2], Model = " Omen 16", Processor = Core.ProcessorType.AMD, RAM = 32, StorageInGB = 1000},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[3], Model = " MacBook Air 13.3", Processor = Core.ProcessorType.Apple, RAM = 8, StorageInGB = 256},
                new BO.Laptop() {Id = Guid.NewGuid(), Producer = producers[3], Model = " MacBook Pro", Processor = Core.ProcessorType.Apple, RAM = 18, StorageInGB = 512}
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

    }
}