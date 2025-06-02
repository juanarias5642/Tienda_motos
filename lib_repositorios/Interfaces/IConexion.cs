using System.Collections.Generic;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConnection { get; set; }

        DbSet<Motocicletas>? Motocicletas { get; set; }
        DbSet<Chasises>? Chasises { get; set; }
        DbSet<Fact_motos>? Fact_motos { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<Referencias>? Referencias { get; set; }
        DbSet<Tipos>? Tipos { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
