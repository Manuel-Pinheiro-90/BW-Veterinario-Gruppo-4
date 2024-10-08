﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Ricovero>> GetRicoveriMensili()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var list = await _ctx.Ricoveri.Where(r => r.DataFineRicovero == null || (r.DataFineRicovero.Value.Year == currentYear && r.DataFineRicovero.Value.Month == currentMonth)).Include(r => r.Animale).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Ricovero>> GetRicoveriAttivi()
        {
            var list = await _ctx.Ricoveri.Where(r => r.DataFineRicovero == null).Include(r => r.Animale).ToListAsync();
            return list;
        }

        public async Task<Ricovero> GetById(int id)
        {
            var ricovero = await _ctx.Ricoveri.Where(r => r.IdRicovero == id).SingleOrDefaultAsync();
            return ricovero;
        }

        public async Task<Ricovero> EditRicovero(int id)
        {
            var ricovero = await GetById(id);
            ricovero.DataFineRicovero = DateTime.Now;

            _ctx.Ricoveri.Update(ricovero);
            await _ctx.SaveChangesAsync();

            return ricovero;
        }
    }
}
