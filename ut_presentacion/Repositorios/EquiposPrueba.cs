using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class EquiposPrueba
    {
        private readonly IConexion? iConexion;
        private List<Motocicletas>? lista_motocicletas;
        private Motocicletas? entidad_motocicletas;
        private List<Chasises>? lista_chasises;
        private Chasises? entidad_chasises;
        private List<Fact_motos>? lista_facmotos;
        private Fact_motos? entidad_facmotos;
        private List<Facturas>? lista_facturas;
        private Facturas? entidad_facturas;
        private List<Marcas>? lista_marcas;
        private Marcas? entidad_marcas;
        private List<Personas>? lista_personas;
        private Personas? entidad_personas;
        private List<Referencias>? lista_referencias;
        private Referencias? entidad_referencias;
        private List<Tipos>? lista_tipos;
        private Tipos? entidad_tipos;



        public EquiposPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConnection = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarChasises());
            Assert.AreEqual(true, ModificarChasises());
            Assert.AreEqual(true, ListarChasises());
            //Assert.AreEqual(true, BorrarChasises());//
            Assert.AreEqual(true, GuardarMarcas());
            Assert.AreEqual(true, ModificarMarcas());
            Assert.AreEqual(true, ListarMarcas());
            //Assert.AreEqual(true, BorrarMarcas());//
            Assert.AreEqual(true, GuardarPersonas());
            Assert.AreEqual(true, ModificarPersonas());
            Assert.AreEqual(true, ListarPersonas());
            //Assert.AreEqual(true, BorrarPersonas());//
            Assert.AreEqual(true, GuardarReferencias());
            Assert.AreEqual(true, ModificarReferencias());
            Assert.AreEqual(true, ListarReferencias());
            //Assert.AreEqual(true, BorrarReferencias());//
            Assert.AreEqual(true, GuardarTipos());
            Assert.AreEqual(true, ModificarTipos());
            Assert.AreEqual(true, ListarTipos());
            //Assert.AreEqual(true, BorrarTipos());//
            Assert.AreEqual(true, GuardarMotocicletas());
            Assert.AreEqual(true, ModificarMotocicletas());
            Assert.AreEqual(true, ListarMotocicletas());
            //Assert.AreEqual(true, BorrarMotocicletas());//
            Assert.AreEqual(true, GuardarFact_motos());
            Assert.AreEqual(true, ModificarFact_motos());
            Assert.AreEqual(true, ListarFact_motos());
            //Assert.AreEqual(true, BorrarFact_motos());//
            Assert.AreEqual(true, GuardarFacturas());
            Assert.AreEqual(true, ModificarFacturas());
            Assert.AreEqual(true, ListarFacturas());
            //Assert.AreEqual(true, BorrarFacturas());//

        }

        public bool ListarMotocicletas()
        {
            this.lista_motocicletas = this.iConexion!.Motocicletas!.ToList();
            return lista_motocicletas.Count > 0;
        }

        public bool ListarChasises()
        {
            this.lista_chasises = this.iConexion!.Chasises!.ToList();
            return lista_chasises.Count > 0;
        }

        public bool ListarFact_motos()
        {
            this.lista_facmotos = this.iConexion!.Fact_motos!.ToList();
            return lista_facmotos.Count > 0;
        }

        public bool ListarFacturas()
        {
            this.lista_facturas = this.iConexion!.Facturas!.ToList();
            return lista_facturas.Count > 0;
        }

        public bool ListarMarcas()
        {
            this.lista_marcas = this.iConexion!.Marcas!.ToList();
            return lista_marcas.Count > 0;
        }

        public bool ListarPersonas()
        {
            this.lista_personas = this.iConexion!.Personas!.ToList();
            return lista_personas.Count > 0;
        }

        public bool ListarReferencias()
        {
            this.lista_referencias = this.iConexion!.Referencias!.ToList();
            return lista_referencias.Count > 0;
        }

        public bool ListarTipos()
        {
            this.lista_tipos = this.iConexion!.Tipos!.ToList();
            return lista_tipos.Count > 0;
        }



        public bool GuardarChasises()
        {
            this.entidad_chasises = EntidadesNucleo.Chasises()!;
            this.iConexion!.Chasises!.Add(this.entidad_chasises);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarFact_motos()
        {
            this.entidad_facmotos = EntidadesNucleo.Fact_motos()!;
            this.iConexion!.Fact_motos!.Add(this.entidad_facmotos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarFacturas()
        {
            this.entidad_facturas = EntidadesNucleo.Facturas()!;
            this.iConexion!.Facturas!.Add(this.entidad_facturas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarMarcas()
        {
            this.entidad_marcas = EntidadesNucleo.Marcas()!;
            this.iConexion!.Marcas!.Add(this.entidad_marcas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarPersonas()
        {
            this.entidad_personas = EntidadesNucleo.Personas()!;
            this.iConexion!.Personas!.Add(this.entidad_personas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarReferencias()
        {
            this.entidad_referencias = EntidadesNucleo.Referencias()!;
            this.iConexion!.Referencias!.Add(this.entidad_referencias);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarTipos()
        {
            this.entidad_tipos = EntidadesNucleo.Tipos()!;
            this.iConexion!.Tipos!.Add(this.entidad_tipos);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool GuardarMotocicletas()
        {
            this.entidad_motocicletas = EntidadesNucleo.Motocicletas()!;
            this.iConexion!.Motocicletas!.Add(this.entidad_motocicletas);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarMotocicletas()
        {

            var entry = this.iConexion!.Entry<Motocicletas>(this.entidad_motocicletas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarChasises()
        {
            var entry = this.iConexion!.Entry<Chasises>(this.entidad_chasises);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarFact_motos()
        {

            var entry = this.iConexion!.Entry<Fact_motos>(this.entidad_facmotos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarFacturas()
        {

            var entry = this.iConexion!.Entry<Facturas>(this.entidad_facturas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarMarcas()
        {

            var entry = this.iConexion!.Entry<Marcas>(this.entidad_marcas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarPersonas()
        {

            var entry = this.iConexion!.Entry<Personas>(this.entidad_personas);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarReferencias()
        {

            var entry = this.iConexion!.Entry<Referencias>(this.entidad_referencias);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool ModificarTipos()
        {

            var entry = this.iConexion!.Entry<Tipos>(this.entidad_tipos);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarMotocicletas()
        {
            this.iConexion!.Motocicletas!.Remove(this.entidad_motocicletas!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarChasises()
        {
            this.iConexion!.Chasises!.Remove(this.entidad_chasises!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarFact_motos()
        {
            this.iConexion!.Fact_motos!.Remove(this.entidad_facmotos!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarFacturas()
        {
            this.iConexion!.Facturas!.Remove(this.entidad_facturas!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarMarcas()
        {
            this.iConexion!.Marcas!.Remove(this.entidad_marcas!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarPersonas()
        {
            this.iConexion!.Personas!.Remove(this.entidad_personas!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarReferencias()
        {
            this.iConexion!.Referencias!.Remove(this.entidad_referencias!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool BorrarTipos()
        {
            this.iConexion!.Tipos!.Remove(this.entidad_tipos!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
