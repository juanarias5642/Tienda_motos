using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asp_presentacion
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Este método se llama por el runtime. Úsalo para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            // Inyección de dependencias para presentaciones
            services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
            services.AddScoped<ITiposPresentacion, TiposPresentacion>();
            services.AddScoped<IChasisesPresentacion, ChasisesPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IReferenciasPresentacion, ReferenciasPresentacion>();
            services.AddScoped<IMotocicletasPresentacion, MotocicletasPresentacion>();
            services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
            services.AddScoped<IFact_motosPresentacion, Fact_motosPresentacion>();

            // Añadir servicios de MVC, Razor Pages y sesiones
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        // Este método se llama por el runtime. Úsalo para configurar el pipeline HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Sirve archivos estáticos desde wwwroot
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
