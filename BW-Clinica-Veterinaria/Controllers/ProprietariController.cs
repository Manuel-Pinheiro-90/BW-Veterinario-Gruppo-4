using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class ProprietariController : Controller
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietariController(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }


        public async Task<IActionResult> Index()
        {
            var proprietari = await _proprietarioService.GetAll();
            return View(proprietari);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _proprietarioService.GetById(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create([Bind("CodiceFiscale,Nome,Cognome,NumeroTelefono")] Proprietario proprietario)
        {
            await _proprietarioService.Create(proprietario);
            return RedirectToAction("Index");



        }

        public async Task<IActionResult> Edit (string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _proprietarioService.GetById(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodiceFiscale,Nome,Cognome,NumeroTelefono")] Proprietario proprietario)
        {



        }












    }


}
