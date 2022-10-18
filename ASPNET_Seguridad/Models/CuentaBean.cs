using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Seguridad.Models
{
    public class CuentaBean
    {
        private List<Cuenta> cuentas;
        public CuentaBean() {
            cuentas = new List<Cuenta> { 
                new Cuenta(){ 
                    usuario = "pepe",
                    password = "123456",
                    rol = new string[]{"empleado","admin"}
                },
                new Cuenta(){
                    usuario = "ana",
                    password = "654321",
                    rol = new string[]{"empleado","admin","su"}
                },
                new Cuenta(){
                    usuario = "sofia",
                    password = "111",
                    rol = new string[]{"empleado"}
                }
            };
        }
        public Cuenta getCuenta(string usuario) {
            return cuentas.SingleOrDefault(c => c.usuario.Equals(usuario));
        }
        public Cuenta realizarLogin(string usuario, string password) {
            return cuentas.SingleOrDefault(c => c.usuario.Equals(usuario)
            && c.password.Equals(password));
        }
    }
}
