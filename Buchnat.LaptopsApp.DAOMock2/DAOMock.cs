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
            throw new NotImplementedException();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IProducer CreateNewProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }

        //       public void DeleteLaptop(int id)
        //     {
        //       throw new NotImplementedException();
        // }

        //        public void DeleteProducer(int id)
        //      {
        //        throw new NotImplementedException();
        //  }

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
            throw new NotImplementedException();
        }

        public IProducer GetProducer(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveLaptop(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveLaptop(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProducer(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProducer(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLaptop(ILaptop laptop)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }

        //    public ILaptop GetLaptopById(int id)
        //      {
        //            throw new NotImplementedException();
        //}

        //  public IProducer GetProducerById(int id)
        //    {
        //          throw new NotImplementedException();
        //        }

        //    public void UpdateLaptop(ILaptop laptop)
        //      {
        //            throw new NotImplementedException();
        //        }

        //        public void UpdateProducer(IProducer producer)
        //    {
        //      throw new NotImplementedException();
        //      }
        //    }
        //}
    }
}