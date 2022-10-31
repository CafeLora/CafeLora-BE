using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Usuario : IdentityUser // Should be called ApplicationUser
    {
        public Guid? EspecialidadId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public string Codigo { get; set; }
    }
}