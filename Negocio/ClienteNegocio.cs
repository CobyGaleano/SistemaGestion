using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado FROM CLIENTE");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Correo = (string)datos.Lector["Correo"];
                    aux.Telefono  = (string)datos.Lector["Telefono"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    listaCliente.Add(aux);
                }
                return listaCliente;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int IdClienteGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                    CREATE PROCEDURE SP_RegistrarCliente(
                    @Documento VARCHAR(50),
                    @NombreCompleto VARCHAR(100),
                    @Correo VARCHAR(100),
                    @Telefono VARCHAR(50),
                    @Estado BIT,
                    @Resultado INT OUTPUT,
                    @Mensaje VARCHAR(500) OUTPUT)    
                */

                datos.setearConsulta("SP_RegistrarCliente", true);
                datos.setearParametros("@Documento", obj.Documento);
                datos.setearParametros("@NombreCompleto", obj.NombreCompleto);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Telefono", obj.Telefono);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdClienteGenerado = Convert.ToInt32(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdClienteGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdClienteGenerado;
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                   CREATE PROC Sp_ModificarCliente(
                   @IdCliente INT,
                   @Documento VARCHAR(50),
                   @NombreCompleto VARCHAR(100),
                   @Correo VARCHAR(100),
                   @Telefono VARCHAR(50),
                   @Estado BIT,
                   @Resultado INT OUTPUT,
                   @Mensaje VARCHAR(500) OUTPUT)
                */

                datos.setearConsulta("Sp_ModificarCliente", true);
                datos.setearParametros("@IdCliente", obj.IdCliente);
                datos.setearParametros("@NombreCompleto", obj.NombreCompleto);
                datos.setearParametros("@Correo", obj.Correo);
                datos.setearParametros("@Telefono", obj.Telefono);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();
                respuesta = Convert.ToBoolean(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();


            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM CLIENTE WHERE IdCliente = @IdCliente", true);
                datos.setearParametros("@IdCliente", obj.IdCliente);

                respuesta = datos.ejecutarAccionResultado();

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
