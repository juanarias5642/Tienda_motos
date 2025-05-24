using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Marcas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pais_origen { get; set; }

        public List<Motocicletas> Motocicletas { get; set; }

    }
}
