using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonasPresentacion
    {
        Task<List<Personas>> Listar();
        Task<List<Personas>> PorCodigo(Personas? entidad);
        Task<Personas?> Guardar(Personas? entidad);
        Task<Personas?> Modificar(Personas? entidad);
        Task<Personas?> Borrar(Personas? entidad);
    }
}