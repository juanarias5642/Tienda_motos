using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFact_motosPresentacion
    {
        Task<List<Fact_motos>> Listar();
        Task<List<Fact_motos>> PorCodigo(Fact_motos? entidad);
        Task<Fact_motos?> Guardar(Fact_motos? entidad);
        Task<Fact_motos?> Modificar(Fact_motos? entidad);
        Task<Fact_motos?> Borrar(Fact_motos? entidad);
    }
}   

