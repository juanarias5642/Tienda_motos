using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMotocicletasAplicacion
    {
        void Configurar(string StringConexion);
        List<Motocicletas> PorCodigo(Motocicletas? entidad);
        List<Motocicletas> Listar();
        Motocicletas? Guardar(Motocicletas? entidad);
        Motocicletas? Modificar(Motocicletas? entidad);
        Motocicletas? Borrar(Motocicletas? entidad);
    }
}
