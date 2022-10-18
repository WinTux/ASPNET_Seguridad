using ASPNET_Seguridad.Herramientas;
using ASPNET_Seguridad.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Seguridad.Controllers
{
    public class CuentaController : Controller
    {
        private AdministracionSeguridad administracion = new AdministracionSeguridad();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string usuario, string password) {
            CuentaBean cuentaBean = new CuentaBean();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password)
                || cuentaBean.realizarLogin(usuario, password) == null)
            {
                ViewBag.mensaje = "Error al autenticar";
                return View("Index");
            }
            else {
                administracion.SingIn(this.HttpContext, cuentaBean.getCuenta(usuario));
                return RedirectToAction("Bienvenido");
            }
        }
        public IActionResult Bienvenido()
        {
            return View("Bienvenido");
        }
        public IActionResult AccesoDenegado()
        {
            return View("AccesoDenegado");
        }
        public IActionResult Logout()
        {
            administracion.SignOut(this.HttpContext);
            ViewBag.mensaje = "Logout con éxito";
            return View("Index");
        }
    }
}
