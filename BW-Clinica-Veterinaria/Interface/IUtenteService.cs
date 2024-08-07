using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IUtenteService
    {
        public Task<Utente> Login(LoginDto loginDto);
        public Task<bool> Register(RegisterDto registerDto);
        public Task Logout();
        public Task<List<Ruolo>> GetRuoli();
    }
}
