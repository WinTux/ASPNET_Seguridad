using ASPNET_Seguridad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Seguridad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            //Abrir *.csproj y agregar lo que está en las lineas 6 a 8 (nombre arbitrario)
            //Ver > Terminal (o solo presionar Crtl+ñ)
            //Nos vamos hasta el folder de nuestro proyecto (NO el de la solución)
            //dotnet user-secrets set "usuario" "pepe"
            //Podemos ver los valores en: 
            //C:\Users\<Uusario>\AppData\Roaming\Microsoft\UserSecrets\<Nombre_UserSecretsId>
            var unValor = _config["usuario"];
            ViewBag.val = unValor;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
