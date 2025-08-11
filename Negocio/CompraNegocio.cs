using Dominio;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool RegistrarCompra(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("sp_RegistrarCompra", true);
                datos.setearParametros("@IdUsuario", obj.IdCompra);
                datos.setearParametros("@IdProveedor",obj.oProveedor.IdProveedor);
                datos.setearParametros("@TipoDocumento",obj.TipoDocumento);
                datos.setearParametros("@NumeroDocumento",obj.NumeroDocumento);
                datos.setearParametros("@MontoTotal",obj.MontoTotal);
                datos.setearParametros("@DetalleCompra", DetalleCompra);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();
                resultado = Convert.ToBoolean(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje += ex.ToString();
            }
            return resultado;
        }

    
    }
}
