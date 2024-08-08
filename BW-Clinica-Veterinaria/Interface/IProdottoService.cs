using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IProdottoService
    {
        Task<IEnumerable<Prodotto>> GetAllProdottiAsync();
        Task<Prodotto> GetProdottoByIdAsync(int id);

        Task UpdateProdottoAsync(Prodotto prodotto);
        Task<Prodotto> AddProdottoAsync(ProdottoDto prodotto, List<int> utilizziId);
       

        Task<List<Utilizzo>> GetUtilizziAsync();
        Task<bool> DeleteProdottoAsync(int id);
        Task<IEnumerable<Prodotto>> GetNomeProdotto(string nome);
        public Task<IEnumerable<Cassetto>> GetCassettiAsync();
    }
}
