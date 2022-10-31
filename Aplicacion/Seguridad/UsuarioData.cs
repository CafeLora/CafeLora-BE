using System;

namespace Aplicacion.Seguridad
{
    public class UsuarioData
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }

        public string Token { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Imagen { get; set; }
        public string Rol { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Entity { get; set; }
    }
}