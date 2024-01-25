using LaptopsApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsApp.Web.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ProducerService _producerService;

        public ProducerController(ProducerService producerService)
        {
            _producerService = producerService;
        }

        public IActionResult Index()
        {
            var producers = _producerService.GetAllProducers();
            return View(producers);
        }
    }
}
