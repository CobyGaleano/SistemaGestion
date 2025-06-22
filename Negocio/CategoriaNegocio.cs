using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdCategoria, Descripcion, Estado FROM CATEGORIA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["IdCategoria"];
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Estado = (bool)datos.Lector["Estado"];

                    listaCategoria.Add(aux);
                }
                return listaCategoria;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            int IdCategoriaGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_RegistrarCategoria(
                    @Descripcion VARCHAR(50),
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT
               )*/

                datos.setearConsulta("SP_RegistrarCategoria", true);
                datos.setearParametros("@Descripcion",obj.Descripcion);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@IdResultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdCategoriaGenerado = Convert.ToInt32(datos.obtenerValorParametro("@IdResultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdCategoriaGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdCategoriaGenerado;
        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_EditarCategoria(
                    @IdCategoria INT,
                    @Descripcion VARCHAR(50),
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT)
                */

                datos.setearConsulta("SP_EditarCategoria", true);
                datos.setearParametros("@Descripcion",obj.Descripcion);
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

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC SP_EliminarCategoria(
                    @IdCategoria INT,
                    @Resultado BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT
                )*/

                datos.setearConsulta("SP_EliminarCategoria", true);
                datos.setearParametros("@IdCategoria", obj.Id);
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

        /*public List<Categoria> listar() ///CLASE CATEGORIA NEGOCIO VIEJA (USADA EN PROYECTO UNIVERSITARIO)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        public void Agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT into CATEGORIAS (Descripcion) values (@Descripcion)");
                datos.setearParametros("@Descripcion", nueva.Descripcion);

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
                datos.setearConsulta("delete from CATEGORIAS where id = @id");
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
