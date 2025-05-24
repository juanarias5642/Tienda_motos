using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Fact_motosAplicacion : IFact_motosAplicacion
    {
        private IConexion? IConexion = null;

        public Fact_motosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Fact_motos? Borrar(Fact_motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Fact_motos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Fact_motos? Guardar(Fact_motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Fact_motos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Fact_motos> Listar()
        {
            return this.IConexion!.Fact_motos!.Take(20).ToList();
        }

        public List<Fact_motos> PorCodigo(Fact_motos? entidad)
        {
            return this.IConexion!.Fact_motos!
                .Where(x => x.Cantidad!.Contains(entidad!.Cantidad!))
                .ToList();
        }

        public Fact_motos? Modificar(Fact_motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Fact_motos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
