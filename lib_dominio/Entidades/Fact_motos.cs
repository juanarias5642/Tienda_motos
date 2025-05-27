using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Fact_motos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public int Factura { get; set; }
        public int Moto { get; set; }
        public string? Cantidad { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Factura")]
        public Facturas? _Factura { get; set; }

        [ForeignKey("Moto")]
        public Motocicletas? _Moto { get; set; } = new();

    }
}
