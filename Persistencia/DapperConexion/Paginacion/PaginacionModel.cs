using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Paginacion
{
    public class PaginacionModel
    {
        public List<IDictionary<string, object>> ListaRecords { get; set; } // se convierte a json
        public int TotalRecords { get; set; }
        public int NumeroPaginas { get; set; }
    }
}
