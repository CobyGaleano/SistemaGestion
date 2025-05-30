﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock {  get; set; }
        public decimal Precio { get; set; } 
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public Categoria categoria { get; set; }
        public Marca marca { get; set; }
        public Imagen imagen { get; set; }
        public List<Imagen> imagenes { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }

    }
}
 