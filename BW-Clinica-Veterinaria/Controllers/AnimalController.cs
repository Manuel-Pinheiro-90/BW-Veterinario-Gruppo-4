using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Dto;
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

        public async Task<IActionResult> CercaPerMicrochip()
        {
            return View();
        }

        public async Task<IActionResult> CercaPerMicrochip(string microchip)
        {
            var animale = await _animalService.GetByMicroChip(microchip);
            if (animale == null)
            {
                return Json(new { success = false, message = "Nessun animale trovato con questo codice microchip." });
            }
            return Json(new { success = true, data = animale });
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///

        public async Task<IActionResult> Details(int id)
        {
            var animale = await _animalService.GetById(id);
            if (animale == null)
            {
                return NotFound();
            }
            return View(animale);
        }

        public async Task<IActionResult> Visite(int id)
        {
            var animale = await _animalService.GetById(id);
            if (animale == null)
            {
                return NotFound();
            }

            ViewBag.Animale = animale;
            var visite = await _animalService.GetVisiteByAnimaleId(id);
            return View(visite);
        }

        public IActionResult AggiungiVisita(int idAnimale)
        {
            var visita = new Visita { IdAnimale = idAnimale, Data = DateTime.Now };
            return View(visita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiVisita([Bind("IdAnimale,Data,Esame,CuraPrescritta")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                await _animalService.AggiungiVisita(visita);
                return RedirectToAction("Visite", new { id = visita.IdAnimale });
            }
            return View(visita);
        }




    }
}
