using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UmbralesMaxHumedad
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Ejecuta>
        {
            //   public int Id { get; set; }
            public double Ultimo { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Ejecuta>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                this._context = context;
            }
            public async Task<Ejecuta> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //    var umbralExists = await _context.UmbralMaxTemperatura.Where(pr => pr.Id == request.Id).FirstOrDefaultAsync();

                //  var lastUmbral = _context.UmbralMaxTemperatura.OrderByDescending(ev => ev.Id).FirstOrDefault().Id;
                //var auxUmbral = 0;

                //                if (auxUmbral < lastUmbral)
                //                  auxUmbral = auxUmbral+ lastUmbral;

                //  if (umbralExists == null)
                //{


                var umbral = new UmbralMaxHumedad
                {
                    // Id=lastUmbral+1,
                    Ultimo = request.Ultimo,
                };

                _context.UmbralMaxHumedad.Add(umbral);
                // }

                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return request;
                }

                throw new Exception("No se pudo insertar el umbral");
            }
        }
    }
}
