using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IAnimalService _animalService;
        private readonly IProprietarioService _proprietarioService;
        private readonly IRicoveroService _ricoveroService;

        public AnimalController(DataContext dbContext, IAnimalService animalService, IProprietarioService proprietarioService, IRicoveroService ricoveroService)
        {
            _ctx = dbContext;
            _animalService = animalService;
            _proprietarioService = proprietarioService;
            _ricoveroService = ricoveroService;
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

        // Il ricovero può essere effettutato solo su animali registrati, poiché necessita del campo animaleId
        // Se un animale non noto dovesse essere ricoverato deve prima essere registrato, per poi poter registrare il ricovero
        public async Task<IActionResult> AggiungiRicovero()
        {
            ViewBag.Animali = await _animalService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiRicovero(RicoveroDto model)
        {
            await _ricoveroService.AggiungiRicovero(model);
            return RedirectToAction("Index", "Home");
        }

    }
}
