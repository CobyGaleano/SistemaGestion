﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto {  get; set; }
        public string Correo {  get; set; }
        public string Clave {  get; set; }
        public Rol rRol {  get; set; }
        public bool Estado {  get; set; }
        public string FechaRegistro {  get; set; }
    }
}
