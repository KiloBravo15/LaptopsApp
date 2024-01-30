﻿using Buchnat.LaptopsApp.Interfaces;
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