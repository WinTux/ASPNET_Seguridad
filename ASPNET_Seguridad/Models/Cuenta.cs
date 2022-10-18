namespace ASPNET_Seguridad.Models
{
    public class Cuenta
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string[] rol { get; set; }//cargo, permisos
    }
}
