using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IRicoveroService
    {
        public string ConvertImage(IFormFile file);
        public Task<Ricovero> AggiungiRicovero(RicoveroDto model);
        public Task<IEnumerable<Ricovero>> GetAll();
    }
}
