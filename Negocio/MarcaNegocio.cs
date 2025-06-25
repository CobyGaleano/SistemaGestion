using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            List<Marca> listaMarca = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdMarca, Nombre, Estado FROM MARCA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["IdMarca"];
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Estado = (bool)datos.Lector["Estado"];

                    listaMarca.Add(aux);
                }
                return listaMarca;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Marca obj, out string Mensaje)
        {
            int IdMarcaGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_RegistrarMarca(
                    @Nombre VARCHAR(50),
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT
               )*/

                datos.setearConsulta("SP_RegistrarMarca", true);
                datos.setearParametros("@Nombre", obj.Nombre);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdMarcaGenerado = Convert.ToInt32(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdMarcaGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdMarcaGenerado;
        }

        public bool Editar(Marca obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_EditarMarca(
                    @IdMarca INT,
                    @Nombre VARCHAR(50),
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT)
                */

                datos.setearConsulta("SP_EditarMarca", true);
                datos.setearParametros("@IdMarca", obj.Id);
                datos.setearParametros("@Nombre", obj.Nombre);
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

        public bool Eliminar(Marca obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_EliminarMarca(
                    @IdMarca INT,
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT
                )*/

                datos.setearConsulta("SP_EliminarMarca", true);
                datos.setearParametros("@IdMarca", obj.Id);
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
        /*public List<Marca> listar()  ///CLASE VIEJA PREVIA AL RE-DISEÑO
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Nombre from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into MARCAS (Nombre) values(@Nombre)");
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {   
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from MARCAS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

    }
}

