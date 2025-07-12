using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdProveedor, Documento, RazonSocial, Correo, Telefono, Estado FROM PROVEEDOR");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IdProveedor = (int)datos.Lector["IdProveedor"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    listaProveedor.Add(aux);
                }
                return listaProveedor;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int IdProveedorGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                    CREATE PROC SP_RegistarProveedor(
                    @Documento VARCHAR(50),
                    @RazonSocial VARCHAR(100),
                    @Correo VARCHAR(100),
                    @Telefono VARCHAR(50),
                    @Estado BIT,
                    @Resultado INT OUTPUT,
                    @Mensaje VARCHAR(500) OUTPUT)    
                */

                datos.setearConsulta("SP_RegistrarProveedor", true);
                datos.setearParametros("@Documento", obj.Documento);
                datos.setearParametros("@RazonSocial", obj.RazonSocial);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Telefono", obj.Telefono);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdProveedorGenerado = Convert.ToInt32(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdProveedorGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdProveedorGenerado;
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                    CREATE PROC SP_ModificarProveedor(
                    @Documento VARCHAR(50),
                    @RazonSocial VARCHAR(100),
                    @Correo VARCHAR(100),
                    @Telefono VARCHAR(50),
                    @Estado BIT,
                    @Resultado INT OUTPUT,
                    @Mensaje VARCHAR(500) OUTPUT)
                */

                datos.setearConsulta("SP_ModificarProveedor", true);
                datos.setearParametros("@IdProveedor", obj.IdProveedor);
                datos.setearParametros("@Documento", obj.Documento);
                datos.setearParametros("@RazonSocial", obj.RazonSocial);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Telefono", obj.Telefono);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();
                Resultado = Convert.ToBoolean(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();


            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }

            return Resultado;
        }

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*  
                    CREATE PROC SP_EliminarProveedor(
                    @IdProveedor INT,
                    @Resultado INT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT)
                */

                datos.setearConsulta("SP_EliminarProveedor", true);
                datos.setearParametros("@IdProveedor", obj.IdProveedor);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                Resultado = Convert.ToBoolean(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
    }
}
