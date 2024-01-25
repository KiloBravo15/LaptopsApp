using Buchnat.LaptopsApp.Core;
using LaptopsApp.Web.Models;
using LaptopsApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult Create()
        {
            // Assuming your producer service method returns a list of producers
            var producers = _producerService.GetAllProducers();

            ViewData["Types"] = Enum.GetValues(typeof(ProcessorType));
            ViewBag.Producers = new SelectList(producers, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Laptop laptop)
        {
            if (laptop != null)
            {
                if (!string.IsNullOrEmpty(laptop.ProducerId.ToString()))
                {
                    laptop.Producer = _producerService.GetProducerById(laptop.ProducerId);
                }

                _laptopService.CreateOrUpdateLaptop(laptop);
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }



        public IActionResult Details(string id)
        {
            var laptop = _laptopService.GetLaptopById(new Guid(id));
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var laptop = _laptopService.GetLaptopById(new Guid(id));
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _laptopService.CreateOrUpdateLaptop(laptop);
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var laptop = _laptopService.GetLaptopById(new Guid(id));
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var laptop = _laptopService.GetLaptopById(new Guid(id));
            if (laptop != null)
            {
                _laptopService.RemoveLaptop(new Guid(id));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
