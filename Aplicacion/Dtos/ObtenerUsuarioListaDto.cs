using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class ObtenerUsuarioListaDto
    {
        public string UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }
        public string Rol { get; set; }
    }
}
