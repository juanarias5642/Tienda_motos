using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMotocicletasPresentacion
    {
        Task<List<Motocicletas>> Listar();
        Task<List<Motocicletas>> PorCodigo(Motocicletas? entidad);
        Task<Motocicletas?> Guardar(Motocicletas? entidad);
        Task<Motocicletas?> Modificar(Motocicletas? entidad);
        Task<Motocicletas?> Borrar(Motocicletas? entidad);
    }
}
