using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    class TablaUsuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
