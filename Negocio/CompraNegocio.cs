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
                datos.setearParametros("@IdUsuario", obj.oUsuario.IdUsuario);
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

        public Compra obtenerCompra(string numero)
        {
            Compra obj = new Compra();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT C.IdCompra, U.NombreCompleto, P.Documento, P.RazonSocial, C.TipoDocumento, C.NumeroDocumento,\r\nC.MontoTotal, CONVERT(CHAR(18),C.FechaRegistro,103)[FechaRegistro] FROM COMPRA C\r\nINNER JOIN  USUARIO U ON U.IdUsuario = C.IdUsuario\r\nINNER JOIN PROVEEDOR P ON P.IdProveedor = C.IdProveedor\r\nWHERE C.NumeroDocumento =@numero ");
                datos.setearParametros("@numero",numero);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    /*Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Clave = (string)datos.Lector["Clave"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.rRol = new Rol() { IdRol = Convert.ToInt32(datos.Lector["IdRol"]) };
                    aux.rRol.Descripcion = (string)datos.Lector["Descripcion"];

                    listaUsuario.Add(aux);*/

                    obj = new Compra()
                    {
                        IdCompra = Convert.ToInt32(datos.Lector["IdCompra"]),
                        oUsuario = new Usuario() { NombreCompleto = datos.Lector["NombreCompleto"].ToString()},
                        oProveedor = new Proveedor() { Documento = datos.Lector["Documento"].ToString(), RazonSocial = datos.Lector["RazonSocial"].ToString() },
                        TipoDocumento = (string)datos.Lector["TipoDocumento"].ToString(),
                        NumeroDocumento = datos.Lector["NumeroDocumento"].ToString(),
                        MontoTotal = Convert.ToDecimal(datos.Lector["MontoTotal"].ToString()),
                        FechaRegistro = datos.Lector["FechaRegistro"].ToString()
                    };
                }

            }
            catch (Exception ex)
            {
                obj = new Compra();
            }
            return obj;
        }

        public List<Detalle_Compra> obtenerDetalleCompra(int idCompra)
        {
            List<Detalle_Compra> cLista=new List<Detalle_Compra> ();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT P.Nombre, DC.PrecioCompra, DC.Cantidad, DC.MontoTotal FROM DETALLE_COMPRA DC\r\nINNER JOIN PRODUCTO P ON P.IdProducto = DC.IdProducto\r\nWHERE DC.IdCompra = @idCompra");
                datos.setearParametros("@idCompra", idCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cLista.Add(new Detalle_Compra()
                    {
                        oProducto = new Producto() { Nombre = datos.Lector["Nombre"].ToString()},
                        PrecioCompra = Convert.ToDecimal(datos.Lector["PrecioCompra"].ToString()),
                        Cantidad = Convert.ToInt32(datos.Lector["Cantidad"].ToString()),
                        MontoTotal = Convert.ToDecimal(datos.Lector["MontoTotal"].ToString()),
                    });
                }

            }
            catch (Exception ex)
            {
                cLista = new List<Detalle_Compra>();
            }
            return cLista;
        }

    }
}
