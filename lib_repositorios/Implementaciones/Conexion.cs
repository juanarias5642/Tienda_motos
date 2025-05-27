using System.Collections.Generic;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Motocicletas>? Motocicletas { get; set; }
        public DbSet<Chasises>? Chasises { get; set; }
        public DbSet<Fact_motos>? Fact_motos { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Referencias>? Referencias { get; set; }
        public DbSet<Tipos>? Tipos { get; set; }
        public DbSet<Auditorias> Auditorias { get; set; }



    }
}
