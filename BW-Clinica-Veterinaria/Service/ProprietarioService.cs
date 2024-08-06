using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace BW_Clinica_Veterinaria.Service
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly DataContext _ctx;

        public ProprietarioService(DataContext context)
        {
            _ctx = context;
      
       
 
        }

        public async Task<IEnumerable<Proprietario>> GetAll() 
        {
            return await _ctx.Proprietari.ToListAsync();
        
        }


        public async Task<Proprietario> GetById(string codiceFiscale) 
        { 

        return await _ctx.Proprietari.FindAsync(codiceFiscale);
        
        }





        public async Task Create(Proprietario proprietario)
        {
            var existingProprietario = await _ctx.Proprietari.FindAsync(proprietario.CodiceFiscale);
            if (existingProprietario == null)
            {
                _ctx.Proprietari.Add(proprietario);
            }
            else
            {
                _ctx.Entry(proprietario).State = EntityState.Modified;
            }
            await _ctx.SaveChangesAsync();
        }


        public async Task Update (Proprietario proprietario)
        {
            _ctx.Entry(proprietario).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

        }






        public async Task Delete (string codiceFiscale)
        {
            var proprietario = await _ctx.Proprietari.FindAsync(codiceFiscale);
            await _ctx.SaveChangesAsync();
        }









    }
}
