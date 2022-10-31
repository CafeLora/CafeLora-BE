using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Especialidad
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }

        public Guid RolId { get; set; }
    }
}
