using Microsoft.AspNetCore.Mvc;

namespace BW_Clinica_Veterinaria.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
