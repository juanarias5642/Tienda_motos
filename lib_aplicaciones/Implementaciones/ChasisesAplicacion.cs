using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ChasisesAplicacion : IChasisesAplicacion
    {
        private IConexion? IConexion = null;

        public ChasisesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Chasises? Borrar(Chasises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Chasises!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Chasises? Guardar(Chasises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Chasises!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Chasises> Listar()
        {
            return this.IConexion!.Chasises!.Take(20).ToList();
        }

        public List<Chasises> PorCodigo(Chasises? entidad)
        {
            return this.IConexion!.Chasises!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Chasises? Modificar(Chasises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Chasises>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
