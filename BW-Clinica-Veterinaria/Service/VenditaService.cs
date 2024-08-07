using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using BW_Clinica_Veterinaria.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BW_Clinica_Veterinaria.Service
{
    public class VenditaService : IVenditaService
    {
        private readonly DataContext _ctx;
        public VenditaService(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Vendita>> GetAll()
        {
            return await _ctx.Vendite
                .Include(x => x.Proprietario)
                .Include(x => x.Prodotto)
                .ToListAsync();
        }

        public async Task<Vendita> GetById(int id)
        {
            return await _ctx.Vendite
                .Include(x => x.Proprietario)
                .Include(x => x.Prodotto)
                .FirstOrDefaultAsync(x => x.IdVendita == id);
        }

        public async Task<Vendita> Create(Vendita vendita)
        {
            _ctx.Vendite.Add(vendita);
            await _ctx.SaveChangesAsync();
            return vendita;
        }

        public async Task<Vendita> Update(Vendita vendita)
        {
            _ctx.Vendite.Update(vendita);
            await _ctx.SaveChangesAsync();
            return vendita;
        }

        public async Task<Vendita> Delete(int id)
        {
            var vendita = await _ctx.Vendite.FirstOrDefaultAsync(x => x.IdVendita == id);
            if (vendita != null)
            {
                _ctx.Vendite.Remove(vendita);
                await _ctx.SaveChangesAsync();
            }
            return vendita;
        }
    }
}
