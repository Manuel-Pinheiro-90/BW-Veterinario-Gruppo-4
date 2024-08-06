using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IUserService
    {
        Task<Utente> Login(LoginDto loginDto);
        Task<Utente> Register(RegisterDto registerDto);
        Task Logout();
    }
}
