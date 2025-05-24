using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IFact_motosAplicacion
    {
        void Configurar(string StringConexion);
        List<Fact_motos> PorCodigo(Fact_motos? entidad);
        List<Fact_motos> Listar();
        Fact_motos? Guardar(Fact_motos? entidad);
        Fact_motos? Modificar(Fact_motos? entidad);
        Fact_motos? Borrar(Fact_motos? entidad);
    }
}
