using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select U.IdUsuario, U.Documento, U.NombreCompleto, U.Correo, U.Clave, U.Estado, R.IdRol, R.Descripcion \r\nFROM Usuario U  Inner Join Rol R on R.IdRol = U.IdRol");
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
                    aux.rRol = new Rol() { IdRol = Convert.ToInt32(datos.Lector["IdRol"])};
                    aux.rRol.Descripcion = (string)datos.Lector["Descripcion"];     

                    listaUsuario.Add(aux);
                }
                return listaUsuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int IdUsuarioGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROCEDURE SP_REGISTRARUSUARIO(
                    @Documento varchar(50),
                    @NombreCompleto varchar(100),
                    @Correo varchar(100),
                    @Clave varchar(50),
                    @IdRol int,
                    @Estado bit,
                    @IdUsuarioResultado int output,
                    @Mensaje varchar(500) output
                )*/

                datos.setearConsulta("SP_REGISTRARUSUARIO", true);
                datos.setearParametros("@Documento", obj.Documento);
                datos.setearParametros("@NombreCompleto", obj.NombreCompleto);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Clave", obj.Clave);
                datos.setearParametros("@IdRol", obj.rRol.IdRol);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@IdUsuarioResultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdUsuarioGenerado = Convert.ToInt32(datos.obtenerValorParametro("@IdUsuarioResultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdUsuarioGenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROCEDURE SP_EDITARUSUARIO(
                    @IdUsuario int,
                    @Documento varchar(50),
                    @NombreCompleto varchar(100),
                    @Correo varchar(100),
                    @Clave varchar(50),
                    @IdRol int,
                    @Estado bit,
                    @Respuesta bit output,
                    @Mensaje varchar(500) output)
                */

                datos.setearConsulta("SP_EDITARUSUARIO", true);
                datos.setearParametros("@IdUsuario", obj.IdUsuario);
                datos.setearParametros("@NombreCompleto", obj.NombreCompleto);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Clave", obj.Clave);
                datos.setearParametros("@IdRol", obj.rRol.IdRol);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Respuesta", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();
                respuesta = Convert.ToBoolean(datos.obtenerValorParametro("@Respuesta"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();


            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROCEDURE SP_ELIMINARUSUARIO(
                    @IdUsuario int,
                    @Respuesta bit output,
                    @Mensaje varchar(500) output)
                */

                datos.setearConsulta("SP_ELIMINARUSUARIO", true);
                datos.setearParametros("@IdUsuario", obj.IdUsuario);
                datos.setearParametroSalida("@Respuesta", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                respuesta = Convert.ToBoolean(datos.obtenerValorParametro("@Respuesta"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }

}
