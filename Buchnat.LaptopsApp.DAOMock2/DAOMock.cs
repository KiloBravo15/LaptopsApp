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
                new BO.Producer() {Id = 1, Name = "Huawei"},
                new BO.Producer() {Id = 2, Name = "LG"}
            };
            laptops = new List<ILaptop>()
            {
                new BO.Laptop() {Id = 1, Producer = producers[0], Model =  "MateBook D 16", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512 },
                new BO.Laptop() {Id = 2, Producer = producers[0], Model = "MateBook 16", Processor = Core.ProcessorType.AMD, RAM = 16, StorageInGB = 512 },
                new BO.Laptop() {Id = 3, Producer = producers[1], Model = "Gram 2023", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512},
                new BO.Laptop() {Id = 4, Producer = producers[1], Model = "Gram 2021", Processor = Core.ProcessorType.Intel, RAM = 16, StorageInGB = 512}
            };
        }



        public ILaptop CreateNewLaptop()
        {
            return new BO.Laptop();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
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