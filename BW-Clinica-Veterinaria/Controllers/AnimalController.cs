using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IAnimalService _animalService;

        public AnimalController(DataContext dbContext, IAnimalService animalService)
        {
            _ctx = dbContext;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AggiungiAnimale()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiAnimale(Animale animale)
        {
            await _animalService.AggiungiAnimale(animale);
            return RedirectToAction("Index", "Home");
        }
    }
}
