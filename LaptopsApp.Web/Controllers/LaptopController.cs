using LaptopsApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsApp.Web.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopService _laptopService;
        private readonly ProducerService _producerService;

        public LaptopController(LaptopService laptopService, ProducerService producerService)
        {
            _laptopService = laptopService;
            _producerService = producerService;
        }

        public IActionResult Index()
        {
            var laptops = _laptopService.GetAllLaptops();
            return View(laptops);
        }
    }
}
