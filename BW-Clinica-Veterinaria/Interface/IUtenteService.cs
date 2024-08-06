using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IUtenteService
    {
        Task<Utente> Login(LoginDto loginDto);
        Task<bool> Register(RegisterDto registerDto);
        Task Logout();
    }
}
