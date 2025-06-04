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
            => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();

            services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
            services.AddScoped<ITiposPresentacion, TiposPresentacion>();
            services.AddScoped<IChasisesPresentacion, ChasisesPresentacion>();
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IReferenciasPresentacion, ReferenciasPresentacion>();
            services.AddScoped<IMotocicletasPresentacion, MotocicletasPresentacion>();
            services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
            services.AddScoped<IFact_motosPresentacion, Fact_motosPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(30);
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
