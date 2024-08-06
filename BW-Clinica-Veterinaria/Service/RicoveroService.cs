using Microsoft.EntityFrameworkCore;
using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Service
{
    public class RicoveroService : IRicoveroService
    {
        private readonly DataContext _ctx;

        public RicoveroService(DataContext dbContext)
        {
            _ctx = dbContext;
        }

        public string ConvertImage(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);
                string urlImg = $"data:image/jpeg;base64,{base64String}";

                return urlImg;
            }
        }

        public async Task<Ricovero> AggiungiRicovero(RicoveroDto model)
        {
            var ricovero = new Ricovero
            {
                DataRicovero = model.DataRicovero,
                IdAnimale = model.IdAnimale,
                Foto = ConvertImage(model.Foto)
            };
            _ctx.Ricoveri.Add(ricovero);
            await _ctx.SaveChangesAsync();
            return ricovero;
        }

        public async Task<IEnumerable<Ricovero>> GetAll()
        {
            var list = await _ctx.Ricoveri.Include(r => r.Animale).ToListAsync();
            return list;
        }
    }
}
