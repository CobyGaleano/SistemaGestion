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
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Clave = (string)datos.Lector["Clave"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.rRol = new Rol() { IdRol = Convert.ToInt32(datos.Lector["IdRol"]) };
                    aux.rRol.Descripcion = (string)datos.Lector["Descripcion"];

                    listaUsuario.Add(aux);
                }
                return listaUsuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return obj;
        }
    
    }
}
