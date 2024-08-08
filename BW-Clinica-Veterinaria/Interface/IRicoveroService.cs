using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IRicoveroService
    {
        public string ConvertImage(IFormFile file);
        public Task<Ricovero> AggiungiRicovero(RicoveroDto model);
        public Task<IEnumerable<Ricovero>> GetAll();
        public Task<IEnumerable<Ricovero>> GetRicoveriMensili();
        public Task<IEnumerable<Ricovero>> GetRicoveriAttivi();
        public Task<Ricovero> GetById(int id);
        public Task<Ricovero> EditRicovero(int id);
    }
}
