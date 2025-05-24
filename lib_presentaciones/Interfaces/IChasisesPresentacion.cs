using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IChasisesPresentacion
    {
        Task<List<Chasises>> Listar();
        Task<List<Chasises>> PorCodigo(Chasises? entidad);
        Task<Chasises?> Guardar(Chasises? entidad);
        Task<Chasises?> Modificar(Chasises? entidad);
        Task<Chasises?> Borrar(Chasises? entidad);
    }
}

