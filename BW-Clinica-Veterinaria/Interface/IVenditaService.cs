using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IVenditaService
    {
        Task<IEnumerable<Vendita>> GetAll();
        Task<Vendita> GetById(int id);
        Task<Vendita> Create(Vendita vendita);
        Task<Vendita> Update(Vendita vendita);
        Task<Vendita> Delete(int id);
    }
}
