using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public List<Articulo> ListaArticulo { get; set; }
        public Vendedor Vendedor{ get; set; }
        public Cliente Cliente { get; set; }
        public float Precio {  get; set; }
    }
}
