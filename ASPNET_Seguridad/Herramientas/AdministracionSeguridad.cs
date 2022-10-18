using ASPNET_Seguridad.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace ASPNET_Seguridad.Herramientas
{
    public class AdministracionSeguridad
    {
        private IEnumerable<Claim> getClaimsDeUsuario(Cuenta cuenta) { 
            List<Claim> claims = new List<Claim> ();
            claims.Add(new Claim(ClaimTypes.Name,cuenta.usuario));
            foreach (var r in cuenta.rol)
                claims.Add(new Claim(ClaimTypes.Role, r));
            return claims;
        }
        public async void SingIn(HttpContext contexto, Cuenta cuenta) {
            ClaimsIdentity claim = new ClaimsIdentity(getClaimsDeUsuario(cuenta)
                ,CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claim);
            await contexto.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal
            );
        }
        public async void SignOut(HttpContext contexto) {
            await contexto.SignOutAsync();
        }
    }
}
