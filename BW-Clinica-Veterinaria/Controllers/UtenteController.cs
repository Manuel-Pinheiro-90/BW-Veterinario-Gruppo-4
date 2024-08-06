using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class UtenteController : Controller
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _utenteService.Register(registerDto);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registerDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _utenteService.Login(loginDto);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _utenteService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
