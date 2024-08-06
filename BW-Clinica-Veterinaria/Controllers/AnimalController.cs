using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IAnimalService _animalService;
        private readonly IProprietarioService _proprietarioService;

        public AnimalController(DataContext dbContext, IAnimalService animalService, IProprietarioService proprietarioService)
        {
            _ctx = dbContext;
            _animalService = animalService;
            _proprietarioService = proprietarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AggiungiAnimale()
        {
            ViewBag.Proprietari = await _proprietarioService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiAnimale(Animale animale)
        {
            await _animalService.AggiungiAnimale(animale);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CercaPerMicrochip()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CercaPerMicrochip(string microchip)
        {
            var animale = await _animalService.GetByMicroChip(microchip);
            if (animale == null)
            {
                return Json(new { success = false, message = "Nessun animale trovato con questo codice microchip." });
            }
            return Json(new { success = true, data = animale });
        }
    }
}
