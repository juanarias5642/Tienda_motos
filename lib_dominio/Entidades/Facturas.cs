using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public string? Cod_factura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int Persona { get; set; }

        [ForeignKey("Persona")]
        public Personas? _Persona { get; set; }


        public List<Fact_motos> Fact_Motos { get; set; }
    }
}
