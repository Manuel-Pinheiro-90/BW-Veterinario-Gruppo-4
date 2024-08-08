using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BW_Clinica_Veterinaria.Controllers
{
    [Authorize(Roles = "Veterinario")]

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodiceFiscale,Nome,Cognome,NumeroTelefono")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                await _proprietarioService.Create(proprietario);
                return RedirectToAction(nameof(Index));
            }
            return View(proprietario);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietario = await _proprietarioService.GetByIdWithAnimals(id);
            if (proprietario == null)
            {
                return NotFound();
            }

            return View(proprietario);
        }

        public async Task<IActionResult> Edit(string id)
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
            if (id != proprietario.CodiceFiscale)
            {
                return NotFound();


            }
            if (ModelState.IsValid)
            {

                try
                {
                    await _proprietarioService.Update(proprietario);
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (await _proprietarioService.GetById(proprietario.CodiceFiscale) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(proprietario);

        }

        public async Task<IActionResult> Delete(string id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _proprietarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
