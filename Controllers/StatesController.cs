using DapperProject.Models;
using DapperProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperProject.Controllers
{
    public class StatesController : Controller
    {
        private readonly StateRepository _repository;

        public StatesController(StateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var states = await _repository.GetAllStates();
            return View(states);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StateName")] State state)
        {
            if (ModelState.IsValid)
            {
                await _repository.InsertState(state);
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }
    }
}
