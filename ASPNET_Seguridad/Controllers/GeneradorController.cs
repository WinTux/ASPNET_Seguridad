using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Seguridad.Controllers
{
    public class GeneradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Generar(string textoCod) {
            ViewBag.texto = textoCod;
            return View("Index");
        }
    }
}
