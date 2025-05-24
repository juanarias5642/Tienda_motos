using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class MotocicletasAplicacion : IMotocicletasAplicacion
    {
        private IConexion? IConexion = null;

        public MotocicletasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Motocicletas? Borrar(Motocicletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Motocicletas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Motocicletas? Guardar(Motocicletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Motocicletas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Motocicletas> Listar()
        {
            return this.IConexion!.Motocicletas!.Take(20).ToList();
        }

        public List<Motocicletas> PorCodigo(Motocicletas? entidad)
        {
            return this.IConexion!.Motocicletas!
                .Where(x => x.Modelo!.Contains(entidad!.Modelo!))
                .ToList();
        }

        public Motocicletas? Modificar(Motocicletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Motocicletas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
