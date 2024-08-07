using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BW_Clinica_Veterinaria.Service
{
    public class DittaService : IDittaService
    {
        private readonly DataContext _context;

        public DittaService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ditta>> GetAllDitte()
        {
            return await _context.Ditte.ToListAsync();
        }

        public async Task Create(Ditta ditta)
        {
            var existingDitta = await _context.Ditte.FindAsync(ditta.IdDitta);
            if (existingDitta == null)
            {
                _context.Ditte.Add(ditta);
            }
            else
            {
                _context.Entry(ditta).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Ditta> GetDittaById(int id)
        {

            return await _context.Ditte.FindAsync(id);

        }

        public async Task Delete(int id)
        {
            var ditta = await _context.Ditte.FindAsync(id);
            if (ditta != null)
            {
                _context.Ditte.Remove(ditta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Ditta ditta)
        {
            _context.Entry(ditta).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
