using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Dto;
using BW_Clinica_Veterinaria.Models.Entity;
using BW_Clinica_Veterinaria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BW_Clinica_Veterinaria.Service
{
    public class UtenteService : IUtenteService
    {
        private readonly DataContext _ctx;
        private readonly IPasswordEncoder _passwordEncoder;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UtenteService(DataContext context, IHttpContextAccessor httpContextAccessor, IPasswordEncoder passwordEncoder)
        {
            _ctx = context;
            _httpContextAccessor = httpContextAccessor;
            _passwordEncoder = passwordEncoder;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var utente = new Utente
            {
                Email = registerDto.Email,
                Password = _passwordEncoder.Encode(registerDto.Password) 
            };

            var ruolo = await _ctx.Ruoli.FirstOrDefaultAsync(r => r.Nome == registerDto.Ruolo);
            if (ruolo == null)
            {
                ruolo = new Ruolo { Nome = registerDto.Ruolo };
                _ctx.Ruoli.Add(ruolo);
            }
            utente.Ruoli.Add(ruolo);
            _ctx.Utenti.Add(utente);

            var result = await _ctx.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Utente> Login(LoginDto loginDto)
        {
            var user = await _ctx.Utenti.Include(u => u.Ruoli)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !_passwordEncoder.IsSame(loginDto.Password, user.Password))
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Ruoli.First().Nome),
                new Claim(ClaimTypes.NameIdentifier, user.IdUtente.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return user;
        }

        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
