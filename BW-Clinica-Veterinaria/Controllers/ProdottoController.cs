using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using BW_Clinica_Veterinaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly IProdottoService _prodottoService;


        public ProdottoController(IProdottoService prodottoRepository)
        {
            _prodottoService = prodottoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var prodotti = await _prodottoService.GetAllProdottiAsync();
            return View(prodotti);
        }
        public async Task<IActionResult> Details(int id)
        {
            var prodotto = await _prodottoService.GetProdottoByIdAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Utilizzi = await _prodottoService.GetUtilizziAsync();
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                await _prodottoService.AddProdottoAsync(prodotto);
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var prodotto = await _prodottoService.GetProdottoByIdAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _prodottoService.UpdateProdottoAsync(prodotto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _prodottoService.GetProdottoByIdAsync(id) == null)
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
            return View(prodotto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var prodotto = await _prodottoService.GetProdottoByIdAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prodottoService.DeleteProdottoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
