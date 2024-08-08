using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using BW_Clinica_Veterinaria.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BW_Clinica_Veterinaria.Controllers
{
    [Authorize(Roles = "Farmacista")]
    public class ProdottoController : Controller
    {
        private readonly IProdottoService _prodottoService;
        private readonly IDittaService _dittaService;


        public ProdottoController(IProdottoService prodottoRepository, IDittaService dittaService)
        {
            _prodottoService = prodottoRepository;
            _dittaService = dittaService;
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
            ViewBag.Ditte = await _dittaService.GetAllDitte();
            ViewBag.Cassetti = await _prodottoService.GetCassettiAsync();
            ViewBag.Utilizzi = await _prodottoService.GetUtilizziAsync();
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdottoDto model, List<int> utilizziId)
        {
            if (ModelState.IsValid)
            {
                await _prodottoService.AddProdottoAsync(model, utilizziId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var prodotto = await _prodottoService.GetProdottoByIdAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdotto,IdDitta,Nome,Tipo,IdCassetto,Utilizzi")] Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return NotFound();
            }

            try
            {
                await _prodottoService.UpdateProdottoAsync(prodotto);
                return RedirectToAction(nameof(Index));
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
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////

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

        public async Task<IActionResult> GetNomeProdotto(string nome)
        {
            var prodotto = await _prodottoService.GetNomeProdotto(nome);
            return View("Index", prodotto);
        }
    }
}
