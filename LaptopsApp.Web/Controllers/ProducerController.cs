using LaptopsApp.Web.Models;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producer producer)
        {
            if (!string.IsNullOrWhiteSpace(producer.Name) && !string.IsNullOrWhiteSpace(producer.Description))
            {
                _producerService.CreateOrUpdateProducer(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        public IActionResult Details(string id)
        {
            var producer = _producerService.GetProducerById(new Guid(id));
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var producer = _producerService.GetProducerById(new Guid(id));
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producer producer)
        {
            if (producer != null)
            {
                _producerService.CreateOrUpdateProducer(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var producer = _producerService.GetProducerById(new Guid(id));
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var producer = _producerService.GetProducerById(new Guid(id));
            if (producer != null)
            {
                _producerService.RemoveProducer(new Guid(id));
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
