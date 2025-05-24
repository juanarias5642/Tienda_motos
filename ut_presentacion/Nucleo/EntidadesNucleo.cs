using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Motocicletas? Motocicletas()
        {
            var entidad = new Motocicletas();
            entidad.Modelo = "2023";
            entidad.Cilindraje = 200;
            entidad.Precio = 20000;
            entidad.Tipo = 1;
            entidad.Color = "Pruebas";
            entidad.Referencia = 1;
            entidad.Marca = 1;
            entidad.Chasis = 1;
            return entidad;
        }

        public static Chasises? Chasises()
        {
            var entidad = new Chasises();
            entidad.Nombre = "HG189J";
            entidad.Peso = 148;
            return entidad;
        }
        ///
        public static Fact_motos? Fact_motos()
        {
            var entidad = new Fact_motos();
            entidad.Factura = 1;
            entidad.Moto = 1;

            entidad.Iva = 2000;
            entidad.Precio = 200000;

            return entidad;
        }

        public static Facturas? Facturas()
        {
            var entidad = new Facturas();
            entidad.Cod_factura = "F00012";
            entidad.Fecha = DateTime.Now;
            entidad.Total = 5000000;
            entidad.Persona = 1;
            return entidad;
        }

        public static Marcas? Marcas()
        {
            var entidad = new Marcas();
            entidad.Nombre= "suzuki";
            entidad.Pais_origen = "japon";

            return entidad;
        }

        public static Personas? Personas()
        {
            var entidad = new Personas();
            entidad.Codigo = "103325";
            entidad.Nombre = "miriam";
            entidad.Apellido = "arias";
            return entidad;
        }

        public static Referencias? Referencias()
        {
            var entidad = new Referencias();
            entidad.Nombre = "ns 200";
            entidad.Anio_lanzamiento = 2022;
            return entidad;
        }

        public static Tipos? Tipos()
        {
            var entidad = new Tipos();
            entidad.Nombre = "enduro";
            entidad.Alta_gama = true;
            return entidad;
        }
    }
}