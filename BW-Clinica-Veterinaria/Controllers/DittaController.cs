using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using BW_Clinica_Veterinaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class DittaController : Controller
    {

        private readonly IDittaService _dittaService;
        private readonly DataContext _context;

        public DittaController(IDittaService dittaRepository, DataContext DbContext)
        {
            _dittaService = dittaRepository;
            _context = DbContext;
        }
        public async Task<IActionResult> Index()
        {
            var ditte = await _dittaService.GetAllDitte();
            return View(ditte);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Indirizzo,Recapito")] Ditta ditta)
        {
            if (ModelState.IsValid)
            {
                await _dittaService.Create(ditta);
                return RedirectToAction(nameof(Index));
            }
            return View(ditta);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ditta = await _dittaService.GetDittaById(id);
            if (ditta == null)
            {
                return NotFound();
            }
            return View(ditta);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var ditta = await _dittaService.GetDittaById(id);
            if (ditta == null)
            {
                return NotFound();
            }
            return View(ditta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDitta,Nome,Indirizzo,Recapito")] Ditta ditta)
        {
            if (id != ditta.IdDitta)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _dittaService.Update(ditta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(await _dittaService.GetDittaById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ditta);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ditta = await _dittaService.GetDittaById(id);
            if (ditta == null)
            {
                return NotFound();
            }

            return View(ditta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dittaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
