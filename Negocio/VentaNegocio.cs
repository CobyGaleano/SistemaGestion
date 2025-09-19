using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        public int ObtenerCorrelativo()
        {
            int idCorrelativo = 0;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT (*) + 1 FROM VENTA");
                idCorrelativo = Convert.ToInt32(datos.ejecutarScalar());
            }
            catch (Exception ex)
            {
                idCorrelativo = 0;
            }
            return idCorrelativo;
        }

        public bool restarStock(int idProducto, int cantidad)
        {
            bool respuesta = false;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Stock = Stock - @cantidad WHERE IdProducto = @idProducto");
                datos.setearParametros("@cantidad", cantidad);
                datos.setearParametros("@idProdcuto", idProducto);
                respuesta = datos.ejecutarAccionResultado();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool sumarStock(int idProducto, int cantidad)
        {
            bool respuesta = false;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Stock = Stock + @cantidad WHERE IdProducto = @idProducto");
                datos.setearParametros("@cantidad", cantidad);
                datos.setearParametros("@idProdcuto", idProducto);
                respuesta = datos.ejecutarAccionResultado();
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public bool RegistrarVenta(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("sp_RegistrarVenta", true);
                datos.setearParametros("@IdUsuario", obj.oUsuario.IdUsuario);
                datos.setearParametros("@TipoDocumento", obj.TipoDocumento);
                datos.setearParametros("@NumeroDocumento", obj.NumeroDocumento);
                datos.setearParametros("@DocumentoCliente", obj.DocumentoCliente);
                datos.setearParametros("@NombreCliente", obj.NombreCliente);
                datos.setearParametros("@MontoPago", obj.MontoPago);
                datos.setearParametros("@MontoCambio", obj.MontoCambio);
                datos.setearParametros("@MontoTotal", obj.MontoTotal);
                datos.setearParametros("@DetalleVenta", DetalleVenta);
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

        public Venta obtenerVenta(string numero)
        {
            Venta obj = new Venta();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT C.IdVenta, U.NombreCompleto, C.Documento, C.RazonSocial, C.TipoDocumento, C.NumeroDocumento,\r\nC.MontoTotal, CONVERT(CHAR(18),C.FechaRegistro,103)[FechaRegistro] FROM Venta C\r\nINNER JOIN  USUARIO U ON U.IdUsuario = C.IdUsuario\r\nINNER JOIN CLIENTE C ON C.IdCliente = C.IdCliente\r\nWHERE C.NumeroDocumento =@numero ");
                datos.setearParametros("@numero", numero);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    obj = new Venta()
                    {
                        IdVenta = Convert.ToInt32(datos.Lector["IdVenta"]),
                        oUsuario = new Usuario() { NombreCompleto = datos.Lector["NombreCompleto"].ToString() },
                        DocumentoCliente = datos.Lector["DocumentoCliente"].ToString(),
                        NombreCliente = datos.Lector["NombreCliente"].ToString(),
                        TipoDocumento = (string)datos.Lector["TipoDocumento"].ToString(),
                        NumeroDocumento = datos.Lector["NumeroDocumento"].ToString(),
                        MontoTotal = Convert.ToDecimal(datos.Lector["MontoTotal"].ToString()),
                        FechaRegistro = datos.Lector["FechaRegistro"].ToString()
                    };
                }

            }
            catch (Exception ex)
            {
                obj = new Venta();
            }
            return obj;
        }

        public List<Detalle_Venta> obtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Venta> cLista = new List<Detalle_Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT P.Nombre, DV.PrecioVenta, DV.Cantidad, DV.Subtotal FROM DETALLE_Venta DV\r\nINNER JOIN PRODUCTO P ON P.IdProducto = DV.IdProducto\r\nWHERE DV.IdVenta = @idVenta");
                datos.setearParametros("@idVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cLista.Add(new Detalle_Venta()
                    {
                        oProducto = new Producto() { Nombre = datos.Lector["Nombre"].ToString() },
                        PrecioVenta = Convert.ToDecimal(datos.Lector["PrecioVenta"].ToString()),
                        Cantidad = Convert.ToInt32(datos.Lector["Cantidad"].ToString()),
                        SubTotal = Convert.ToDecimal(datos.Lector["MontoTotal"].ToString()),
                    });
                }

            }
            catch (Exception ex)
            {
                cLista = new List<Detalle_Venta>();
            }
            return cLista;
        }
    }
}
