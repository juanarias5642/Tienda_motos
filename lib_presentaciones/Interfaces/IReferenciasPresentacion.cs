using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReferenciasPresentacion
    {
        Task<List<Referencias>> Listar();
        Task<List<Referencias>> PorCodigo(Referencias? entidad);
        Task<Referencias?> Guardar(Referencias? entidad);
        Task<Referencias?> Modificar(Referencias? entidad);
        Task<Referencias?> Borrar(Referencias? entidad);
    }
}
