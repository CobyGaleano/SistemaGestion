using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {
        public int ObtenerCorrelativo()
        {
            int idCorrelativo = 0;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT (*) + 1 FROM COMPRA");
                datos.ejecutarLectura();
                idCorrelativo = Convert.ToInt32(datos.ejecutarScalar());
            }
            catch (Exception ex)
            {
                idCorrelativo = 0;
            }
            return idCorrelativo;
        }
    }
}
