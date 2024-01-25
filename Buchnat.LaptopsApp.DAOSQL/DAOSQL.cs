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
            return Laptops.ToList().Cast<ILaptop>();
        }

        public IProducer CreateNewProducer(IProducer producer)
        {
            var entity = producer as ProducerDBSQL;
            if (entity != null)
            {
                this.Producers.Add(entity);
                this.SaveChanges();
                return producer;
            }
            throw new ArgumentException("Invalid producer type.");
        }

        public ILaptop CreateNewLaptop(ILaptop laptop)
        {
            var entity = laptop as LaptopDBSQL;
            if (entity != null)
            {
                this.Laptops.Add(entity);
                this.SaveChanges();
                return laptop;
            }
            throw new ArgumentException("Invalid laptop type.");
        }

        public void UpdateLaptop(ILaptop laptop)
        {
            var entity = laptop as LaptopDBSQL;
            if (entity != null)
            {
                this.Laptops.Update(entity);
                this.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid laptop type.");
            }
        }

        public void UpdateProducer(IProducer producer)
        {
            var entity = producer as ProducerDBSQL;
            if (entity != null)
            {
                this.Producers.Update(entity);
                this.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid producer type.");
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
            throw new NotImplementedException();
        }

        public IProducer GetProducer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
