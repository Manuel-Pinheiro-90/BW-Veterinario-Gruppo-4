using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IDittaService
    {
        Task<IEnumerable<Ditta>> GetAllDitte();

        Task Create(Ditta ditta);

        Task<Ditta> GetDittaById(int id);

        Task Update(Ditta ditta);
        Task Delete(int id);
    }
}
