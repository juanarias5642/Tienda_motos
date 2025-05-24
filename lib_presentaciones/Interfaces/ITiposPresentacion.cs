using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITiposPresentacion
    {
        Task<List<Tipos>> Listar();
        Task<List<Tipos>> PorCodigo(Tipos? entidad);
        Task<Tipos?> Guardar(Tipos? entidad);
        Task<Tipos?> Modificar(Tipos? entidad);
        Task<Tipos?> Borrar(Tipos? entidad);
    }
}

