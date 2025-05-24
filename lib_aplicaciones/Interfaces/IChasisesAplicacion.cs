using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IChasisesAplicacion
    {
        void Configurar(string StringConexion);
        List<Chasises> PorCodigo(Chasises? entidad);
        List<Chasises> Listar();
        Chasises? Guardar(Chasises? entidad);
        Chasises? Modificar(Chasises? entidad);
        Chasises? Borrar(Chasises? entidad);
    }
}