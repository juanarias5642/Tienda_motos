using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class TiposAplicacion : ITiposAplicacion
    {
        private IConexion? IConexion = null;

        public TiposAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Tipos? Borrar(Tipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Tipos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Tipos? Guardar(Tipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Tipos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tipos> Listar()
        {
            return this.IConexion!.Tipos!.Take(20).ToList();
        }

        public List<Tipos> PorCodigo(Tipos? entidad)
        {
            return this.IConexion!.Tipos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Tipos? Modificar(Tipos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Tipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
