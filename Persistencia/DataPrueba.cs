using System;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(CafeLoraContext context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    PhoneNumber = "959363398",
                    Nombres = "Diego",
                    Apellidos = "Salas Noain",
                    FechaNacimiento = new DateTime(1991, 08, 08),
                    UserName = "diegosalas",
                    Email = "diegosalas27@gmail.com",
                    Codigo = "AD001"
                };
                await usuarioManager.CreateAsync(usuario, "Password123$");
            }
        }
    }
}