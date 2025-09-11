using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        public Venta obtenerVenta(string numero)
        {
            Venta obj = new Venta();
			try
			{

			}
			catch (Exception ex)
			{
                obj = new Venta();
			}

            return obj;
        }
    }
}
