﻿using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class MarcasAplicacion : IMarcasAplicacion
    {
        private IConexion? IConexion = null;

        public MarcasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConnection = StringConexion;
        }

        public Marcas? Borrar(Marcas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Marcas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Marcas? Guardar(Marcas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Marcas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Marcas> Listar()
        {
            return this.IConexion!.Marcas!.Take(20).ToList();
        }

        public List<Marcas> PorCodigo(Marcas? entidad)
        {
            return this.IConexion!.Marcas!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }

        public Marcas? Modificar(Marcas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Marcas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
