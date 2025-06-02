using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IMarcasAplicacion, MarcasAplicacion>();
            services.AddScoped<IReferenciasAplicacion, ReferenciasAplicacion>();
            services.AddScoped<ITiposAplicacion, TiposAplicacion>();
            services.AddScoped<IChasisesAplicacion, ChasisesAplicacion>();
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IFact_motosAplicacion, Fact_motosAplicacion>();
            services.AddScoped<IMotocicletasAplicacion, MotocicletasAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();

            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }
    }
}