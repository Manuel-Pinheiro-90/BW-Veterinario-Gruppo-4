using Microsoft.EntityFrameworkCore;
using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly DataContext _ctx;

        public AnimalService(DataContext dbContext)
        {
            _ctx = dbContext;
        }

        public async Task<Animale> AggiungiAnimale(Animale animale)
        {
            _ctx.Animali.Add(animale);
            await _ctx.SaveChangesAsync();
            return animale;
        }

        public async Task<IEnumerable<Animale>> GetAll()
        {
            var list = await _ctx.Animali.ToListAsync();
            return list;
        }

        public async Task<Ricovero> GetRicoveroByMicroChip(string microchip)
        {
            var ricovero = await _ctx.Ricoveri
                .Include(r => r.Animale)
                .ThenInclude(a => a.Proprietario)
                .SingleOrDefaultAsync(r => r.Animale.MicroChipCodice == microchip && r.DataFineRicovero == null);

            return ricovero;
        }

        ////////////////////////////////////////////////////////////
        public async Task<Animale> GetById(int id)
        {
            return await _ctx.Animali
                .Include(a=> a.Proprietario)
                .SingleOrDefaultAsync(a => a.IdAnimale == id);
        }

        public async Task<IEnumerable<Visita>> GetVisiteByAnimaleId(int idAnimale)
        {
            return await _ctx.Visite.Where(v => v.IdAnimale == idAnimale).OrderByDescending(v => v.Data).ToListAsync();
        }

        public async Task<Visita> AggiungiVisita(Visita visita)
        {
            _ctx.Visite.Add(visita);
            await _ctx.SaveChangesAsync();
            return visita;
        }










    }
}
