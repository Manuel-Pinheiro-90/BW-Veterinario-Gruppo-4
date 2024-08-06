using BW_Clinica_Veterinaria.Models.Entity;
namespace BW_Clinica_Veterinaria.Interface
{
    public interface IProprietarioService
    {
        Task<IEnumerable<Proprietario>> GetAll();
        Task<Proprietario> GetById(string codiceFiscale);
        Task Create(Proprietario proprietario);
        Task<Proprietario> GetByIdWithAnimals(string codiceFiscale);
        Task Update(Proprietario proprietario);
        Task Delete(string CodiceFiscale);

    }
}
