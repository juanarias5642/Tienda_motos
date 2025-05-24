using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ITiposAplicacion
    {
        void Configurar(string StringConexion);
        List<Tipos> PorCodigo(Tipos? entidad);
        List<Tipos> Listar();
        Tipos? Guardar(Tipos? entidad);
        Tipos? Modificar(Tipos? entidad);
        Tipos? Borrar(Tipos? entidad);
    }
}