using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IAnimalService
    {
        public Task<Animale> AggiungiAnimale(Animale animale);
        public Task<IEnumerable<Animale>> GetAll();
        public Task<Animale> GetByMicroChip(string microchip);

    }
}
