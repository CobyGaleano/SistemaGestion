﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Negocio
    {
        public int IdNegocio { get; set; }
        public string Nombre { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }

        public byte[] Image { get; set; }
    }
}
 