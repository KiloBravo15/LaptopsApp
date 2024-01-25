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
            return _blc.GetLaptops() as IEnumerable<Laptop>;
        }

        public Laptop GetLaptopById(Guid id)
        {
            return _blc.GetLaptopById(id) as Laptop;
        }


        public void RemoveLaptop(Guid id)
        {
            _blc.RemoveLaptop(id);
        }

        public void CreateOrUpdateLaptop(Laptop laptop)
        {
            _blc.CreateOrUpdateLaptop(laptop);
        }

      
    }
}
