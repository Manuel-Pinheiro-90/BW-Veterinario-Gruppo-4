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

        public ProdottoController(IProdottoService prodottoService)
        {
            _prodottoService = prodottoService;
        }

       
        public async Task<ActionResult<IEnumerable<Prodotto>>> GetProdotti()
        {
            var prodotti = await _prodottoService.GetAllProdottiAsync();
            return Ok(prodotti);
        }

      
        public async Task<ActionResult<Prodotto>> GetProdotto(int id)
        {
            var prodotto = await _prodottoService.GetProdottoByIdAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return Ok(prodotto);
        }

        [HttpPost]
        public async Task<ActionResult<Prodotto>> PostProdotto(Prodotto prodotto)
        {
            var newProdotto = await _prodottoService.AddProdottoAsync(prodotto);
            return CreatedAtAction(nameof(GetProdotto), new { id = newProdotto.IdProdotto }, newProdotto);
        }

        [HttpPut]
        public async Task<IActionResult> PutProdotto(int id, Prodotto prodotto)
        {
            if (id != prodotto.IdProdotto)
            {
                return BadRequest();
            }

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

            return NoContent();
        }

       // [HttpGet]
        public IActionResult Create()
        {
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


        [HttpDelete]
        public async Task<IActionResult> DeleteProdotto(int id)
        {
            var deleted = await _prodottoService.DeleteProdottoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
