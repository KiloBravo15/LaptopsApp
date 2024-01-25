using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buchnat.LaptopsApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Buchnat.LaptopsApp.DAOSQL
{
    public class DAOSQL : DbContext, IDAO
    {
        public DbSet<LaptopDBSQL> Laptops { get; set; }
        public DbSet<ProducerDBSQL> Producers { get; set; }

        public string DbPath { get; }

        public DAOSQL()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "laptops.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source=laptops.db");

        IEnumerable<IProducer> IDAO.GetAllProducers()
        {
            return Producers.ToList().Cast<IProducer>();
        }

        IEnumerable<ILaptop> IDAO.GetAllLaptops()
        {
            return Laptops.Select(aircraft => aircraft.ToILaptop(Producers.ToList()));
        }

        public IProducer CreateNewProducer(IProducer producer)
        {
            producer.Id = Guid.NewGuid(); 
            Add(new ProducerDBSQL()
            {
                Id = producer.Id,
                Name = producer.Name,
                Description = producer.Description
            });

            SaveChanges();
            return producer;
        }


        public ILaptop CreateNewLaptop(ILaptop laptop)
        {
            laptop.Id = Guid.NewGuid();
            Add(new LaptopDBSQL()
            {
                Id = laptop.Id,
                Model = laptop.Model,
                Processor = laptop.Processor,
                RAM = laptop.RAM,
                StorageInGB = laptop.StorageInGB,
                ProducerId = laptop.Producer.Id.ToString() 
            });

            SaveChanges();
            return laptop;
        }


        public void UpdateLaptop(ILaptop updatedLaptop)
        {
            var laptop = Laptops.FirstOrDefault(l => l.Id == updatedLaptop.Id);
            if (laptop != null)
            {
                laptop.Model = updatedLaptop.Model;
                laptop.Processor = updatedLaptop.Processor;
                laptop.RAM = updatedLaptop.RAM;
                laptop.StorageInGB = updatedLaptop.StorageInGB;

                Entry(laptop).CurrentValues.SetValues(laptop);
                SaveChanges();
            }
        }


        public void UpdateProducer(IProducer updatedProducer)
        {
            var producer = Producers.FirstOrDefault(p => p.Id == updatedProducer.Id);
            if (producer != null)
            {
                producer.Name = updatedProducer.Name;
                producer.Description = updatedProducer.Description;

                Entry(producer).CurrentValues.SetValues(producer);
                SaveChanges();
            }
        }


        void IDAO.RemoveLaptop(Guid id)
        {
            var laptop = this.Laptops.Find(id);
            if (laptop != null)
            {
                this.Laptops.Remove(laptop);
                this.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Laptop not found.");
            }
        }

        void IDAO.RemoveProducer(Guid id)
        {
            var producer = this.Producers.Find(id);
            if (producer != null)
            {
                this.Producers.Remove(producer);
                this.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Producer not found.");
            }
        }

        public ILaptop GetLaptop(Guid id)
        {
            return (ILaptop)Laptops.Where(laptop => laptop.Id.Equals(id)).FirstOrDefault();
        }

        public IProducer GetProducer(Guid id)
        {
            return (IProducer)Producers.Where(producer => producer.Id.Equals(id)).FirstOrDefault();
        }
    }
}
