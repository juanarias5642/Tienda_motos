using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lib_dominio.Entidades
{
    public class Motocicletas
    {
        public int Id { get; set; }
        public string Cod_moto { get; set; }
        public string? Modelo { get; set; }
        public int Cilindraje { get; set; }
        public decimal Precio { get; set; }
        public string? Color { get; set; }
        public int Tipo { get; set; }
        public int Referencia { get; set; }
        public int Marca { get; set; }
        public int Chasis { get; set; }

        [ForeignKey("Tipo")]
        public Tipos? _Tipo { get; set; }

        [ForeignKey("Referencia")]
        public Referencias? _Referencia { get; set; }

        [ForeignKey("Marca")]
        public Marcas? _Marca { get; set; }

        [ForeignKey("Chasis")]
        public Chasises? _Chasis { get; set; }

        public List<Fact_motos> Fact_motos { get; set; }
    }
}
