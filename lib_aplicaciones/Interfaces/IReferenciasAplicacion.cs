using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IReferenciasAplicacion
    {
        void Configurar(string StringConexion);
        List<Referencias> PorCodigo(Referencias? entidad);
        List<Referencias> Listar();
        Referencias? Guardar(Referencias? entidad);
        Referencias? Modificar(Referencias? entidad);
        Referencias? Borrar(Referencias? entidad);
    }
}
