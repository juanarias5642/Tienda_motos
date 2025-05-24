using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPersonasAplicacion
    {
        void Configurar(string StringConexion);
        List<Personas> PorCodigo(Personas? entidad);
        List<Personas> Listar();
        Personas? Guardar(Personas? entidad);
        Personas? Modificar(Personas? entidad);
        Personas? Borrar(Personas? entidad);
    }
}
