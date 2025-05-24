using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ReferenciasAplicacion : IReferenciasAplicacion
    {
        private IConexion? IConexion = null;

        public ReferenciasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Referencias? Borrar(Referencias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Referencias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Referencias? Guardar(Referencias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Referencias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Referencias> Listar()
        {
            return this.IConexion!.Referencias!.Take(20).ToList();
        }

        public List<Referencias> PorCodigo(Referencias? entidad)
        {
            return this.IConexion!.Referencias!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Referencias? Modificar(Referencias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Referencias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}

