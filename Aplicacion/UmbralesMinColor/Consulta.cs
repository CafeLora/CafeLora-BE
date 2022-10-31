using Aplicacion.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UmbralesMinColor
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMinColorDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMinColorDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMinColorDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralMinColor = await _context.UmbralMinColor
                    .Select(u => new ListarUmbralMinColorDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralMinColor;
            }
        }
    }
}
