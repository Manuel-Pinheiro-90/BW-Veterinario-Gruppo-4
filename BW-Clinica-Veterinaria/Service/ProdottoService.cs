using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BW_Clinica_Veterinaria.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BW_Clinica_Veterinaria.Service
{
    public class ProdottoService : IProdottoService
    {
        private readonly DataContext _context;

        public ProdottoService(DataContext context)
        {
            _context = context;



        }
        public async Task<IEnumerable<Prodotto>> GetAllProdottiAsync()
        {
            return await _context.Prodotti.Include(p => p.Ditta).Include(p => p.Cassetto).ToListAsync();
        }

        public async Task<Prodotto> GetProdottoByIdAsync(int id)
        {
            return await _context.Prodotti.Include(p => p.Ditta).Include(p => p.Cassetto).Include(p => p.Utilizzi)
                .FirstOrDefaultAsync(p => p.IdProdotto == id);
        }

        public async Task<List<Utilizzo>> GetUtilizziAsync()
        {
            return await _context.Utilizzi.ToListAsync();
        }


        public async Task<Prodotto> AddProdottoAsync(Prodotto prodotto)
        {
            _context.Prodotti.Add(prodotto);
            await _context.SaveChangesAsync();
            return prodotto;
        }



        public async Task<Prodotto> UpdateProdottoAsync(Prodotto prodotto)
        {
            _context.Entry(prodotto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return prodotto;
        }

       
        public async Task<bool> DeleteProdottoAsync(int id)
        {
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return false;
            }

            _context.Prodotti.Remove(prodotto);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
