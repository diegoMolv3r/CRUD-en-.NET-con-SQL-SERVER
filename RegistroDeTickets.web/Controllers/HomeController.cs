using Microsoft.AspNetCore.Mvc;

namespace RegistroDeTickets.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
