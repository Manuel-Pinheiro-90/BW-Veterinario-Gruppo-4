using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class VenditaController : Controller
    {
        private readonly IVenditaService _venditaService;
        private readonly IProdottoService _prodottoService;
        private readonly IProprietarioService _proprietarioService;

        public VenditaController(IVenditaService venditaService, IProdottoService prodottoService, IProprietarioService proprietarioService)
        {
            _venditaService = venditaService;
            _prodottoService = prodottoService;
            _proprietarioService = proprietarioService;
        }

        public async Task<IActionResult> Index()
        {
            var vendite = await _venditaService.GetAll();
            return View(vendite);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Prodotti = await _prodottoService.GetAllProdottiAsync();
            ViewBag.Proprietari = await _proprietarioService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendita vendita)
        {
                await _venditaService.Create(vendita);
                return RedirectToAction(nameof(Index)); 
           
        }

        public async Task<IActionResult> Details(int id)
        {
            var vendita = await _venditaService.GetById(id);
            if (vendita == null)
            {
                return NotFound();
            }
            return View(vendita);
        }
    }
}
