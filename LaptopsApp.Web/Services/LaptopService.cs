using Buchnat.LaptopsApp.BLC;
using Buchnat.LaptopsApp.Interfaces;
using LaptopsApp.Web.Models;

namespace LaptopsApp.Web.Services
{
    public class LaptopService
    {
        private readonly BLC _blc; // Assuming BLC has been adapted for Laptops and Producers

        public LaptopService(BLC blc, string dataSource)
        {
            _blc = blc;
            _blc.LoadDatasource(dataSource);
        }
        public IEnumerable<Laptop> GetAllLaptops()
        {
            return _blc.GetLaptops().Select(a => ConvertToModel(a));
        }

        public Laptop GetLaptopById(Guid id)
        {
            return ConvertToModel(_blc.GetLaptopById(id));
        }


        public void RemoveLaptop(Guid id)
        {
            _blc.RemoveLaptop(id);
        }

        public void CreateOrUpdateLaptop(Laptop laptop)
        {
            _blc.CreateOrUpdateLaptop(laptop);
        }

        private Laptop? ConvertToModel(ILaptop laptop)
        {
            return laptop == null ? null : new Laptop
            {
                Id = laptop.Id,
                Producer = ProducerService.ConvertProducerToModel(laptop.Producer), // Assuming you have a similar conversion method for Producer
                Model = laptop.Model,
                Processor = laptop.Processor,
                RAM = laptop.RAM,
                StorageInGB = laptop.StorageInGB
            };
        }


    }
}
