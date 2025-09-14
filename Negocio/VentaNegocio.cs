using Dominio;
using System;
using System.Collections;
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

        public List<Detalle_Venta> obtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Compra> cLista = new List<Detalle_Compra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

            }
            catch (Exception ex)
            {
                cLista = new List<Detalle_Venta>();
            }
            return cLista;
        }
    }
}
