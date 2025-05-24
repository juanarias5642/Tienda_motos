using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Tipos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Alta_gama { get; set; }

        public List<Motocicletas> Motocicletas { get; set; }
    }
}
