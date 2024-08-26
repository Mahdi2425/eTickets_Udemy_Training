using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllProducers = await _service.GetAllAsync();
            return View(AllProducers);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,PictureProfileURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetails =await _service.GetByIdAsync(id);
            if (ProducerDetails == null) return View("NotFound");
            return View(ProducerDetails);
        }

        public async Task<IActionResult> Update(int id)
        {
            var Updatedetail = await _service.GetByIdAsync(id);
            if (Updatedetail == null) return View("NotFound");
            return View(Updatedetail);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("Id,FullName,PictureProfileURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            producer.Id = id;
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var DeleteProducer = await _service.GetByIdAsync(id);
            if (DeleteProducer == null) return View("NotFound");
            return View(DeleteProducer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
