using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Seguridad.Controllers
{
    public class EjemploVistaRestringidaController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="su")]
        public IActionResult Ejemplo1()
        {
            return View();
        }
        [Authorize(Roles = "su,admin")]
        public IActionResult Ejemplo2()
        {
            return View();
        }
        [Authorize(Roles = "su,admin,empleado")]
        public IActionResult Ejemplo3()
        {
            return View();
        }
    }
}
