﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public List<Usuarios> Usuarios { get; set; }

    }
}
