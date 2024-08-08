using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BW_Clinica_Veterinaria.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "Veterinario")]
        public async Task<IActionResult> AggiungiAnimale()
        {
            ViewBag.Proprietari = await _proprietarioService.GetAll();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Veterinario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiAnimale(Animale animale)
        {
            await _animalService.AggiungiAnimale(animale);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public async Task<IActionResult> CercaPerMicrochip()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> CercaPerMicrochipJson(string microchip)
        {
            var ricovero = await _animalService.GetRicoveroByMicroChip(microchip);
            if (ricovero == null)
            {
                return Json(new { success = false, message = "Nessun ricovero trovato con questo codice microchip." });
            }
            return Json(new { success = true, data = ricovero });
        }

        // Il ricovero può essere effettutato solo su animali registrati, poiché necessita del campo animaleId
        // Se un animale non noto dovesse essere ricoverato deve prima essere registrato, per poi poter registrare il ricovero

        [Authorize(Roles = "Veterinario")]
        public async Task<IActionResult> AggiungiRicovero()
        {
            ViewBag.Animali = await _animalService.GetAll();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Veterinario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiRicovero(RicoveroDto model)
        {
            await _ricoveroService.AggiungiRicovero(model);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Veterinario")]
        public async Task<IActionResult> RicoveriMensili()
        {
            var ricoveri = await _ricoveroService.GetRicoveriMensili();
            decimal tariffa = 5;
            decimal totale = 0;
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            foreach (var r in ricoveri)
            {
                var startDate = r.DataRicovero;
                if (firstDayOfMonth > startDate)
                {
                    startDate = firstDayOfMonth;
                }
                var endDate = (r.DataFineRicovero.HasValue ? r.DataFineRicovero.Value : DateTime.Now);
                var giorni = (endDate - startDate).TotalDays;
                totale += (decimal)giorni * tariffa;
            }

            ViewBag.Totale = totale.ToString("F2");

            return View(ricoveri);
        }

        public async Task<IActionResult> ModificaRicovero(int id)
        {
            await _ricoveroService.EditRicovero(id);
            return RedirectToAction(nameof(RicoveriMensili));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Authorize(Roles = "Veterinario")]
        public async Task<IActionResult> Details(int id)
        {
            var animale = await _animalService.GetById(id);
            if (animale == null)
            {
                return NotFound();
            }
            return View(animale);
        }
        [Authorize(Roles = "Veterinario")]
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
        [Authorize(Roles = "Veterinario")]
        public IActionResult AggiungiVisita(int idAnimale)
        {
            var visita = new Visita { IdAnimale = idAnimale, Data = DateTime.Now };
            return View(visita);
        }

        [HttpPost]
        [Authorize(Roles = "Veterinario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AggiungiVisita([Bind("IdVisita,IdAnimale,Data,Esame,CuraPrescritta")] Visita visita)
        {
            await _animalService.AggiungiVisita(visita);
            return RedirectToAction("Visite", new { id = visita.IdAnimale });
        }
    }
}
