using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }

        public string? Contraseña { get; set; }   
        public int Rol { get; set; }

        [ForeignKey("Rol")]
        public Roles? _Rol { get; set; }

    }
}
