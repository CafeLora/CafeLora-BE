using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CafeLora;
using Persistencia;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run(); // crea y ejecuta la aplicacion
            var hostserver = CreateHostBuilder(args).Build();
            using (var ambiente = hostserver.Services.CreateScope()) // Codigo para ejecutar archivo de migracion
            {
                var services = ambiente.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var context = services.GetRequiredService<CafeLoraContext>();
                    context.Database.Migrate();
                    DataPrueba.InsertarData(context, userManager).Wait();
                }
                catch (Exception e)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Ocurrio un error en la migracion");
                }
            }
            hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // toma la configuracion de appsettings.josn o el de desarollo dependiendo del ambiente
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
