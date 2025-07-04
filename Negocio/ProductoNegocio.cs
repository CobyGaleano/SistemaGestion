using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            List<Producto> listaProducto = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, C.IdCategoria, C.Descripcion[DescripcionCategoria], M.IdMarca, M.Nombre[NombreMarca], P.Stock, P.PrecioCompra, P.PrecioVenta, P.Estado FROM PRODUCTO P INNER JOIN CATEGORIA C ON C.IdCategoria = P.IdCategoria INNER JOIN MARCA M ON M.IdMarca = P.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.oCategoria = new Categoria() 
                    {
                        Id = Convert.ToInt32(datos.Lector["IdCategoria"]),
                        Descripcion = (string)datos.Lector["DescripcionCategoria"]
                    };
                    aux.oMarca = new Marca()
                    {
                        Id = Convert.ToInt32(datos.Lector["IdMarca"]),
                        Nombre = (string)datos.Lector["NombreMarca"]
                    };
                    //aux.Stock = (int)datos.Lector["Stock"];
                    //aux.PrecioCompra = (int)datos.Lector["PrecioCompra"];
                    //aux.PrecioVenta = (int)datos.Lector["PrecioVenta"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaProducto.Add(aux);
                }
                return listaProducto;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            int IdProductoGenerado = 0;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*CREATE PROC sp_RegistrarProducto(
                  @Codigo VARCHAR (20),
                  @Nombre VARCHAR (30),
                  @Descripcion VARCHAR (50),
                  @IdCategoria INT,
                  @IdMarca INT,
                  @Estado BIT,
                  @Resultado BIT OUTPUT,
                  @Mensaje VARCHAR (500) OUTPUT)
                */

                datos.setearConsulta("sp_RegistrarProducto", true);
                datos.setearParametros("@Codigo", obj.Codigo);
                datos.setearParametros("@Nombre", obj.Nombre);
                datos.setearParametros("@Descripcion", obj.Descripcion);
                datos.setearParametros("@IdCategoria", obj.oCategoria.Id);
                datos.setearParametros("@IdMarca", obj.oMarca.Id);
                //datos.setearParametros("@Stock", obj.Stock);
                //datos.setearParametros("@PrecioCompra", obj.PrecioCompra);
                //datos.setearParametros("@PrecioVenta", obj.PrecioVenta);
                datos.setearParametros("@Estado", obj.Estado);
                datos.setearParametroSalida("@Resultado", SqlDbType.Int);
                datos.setearParametroSalida("@Mensaje", SqlDbType.VarChar, 500);

                datos.ejecutarAccion();

                IdProductoGenerado = Convert.ToInt32(datos.obtenerValorParametro("@Resultado"));
                Mensaje = datos.obtenerValorParametro("@Mensaje").ToString();

            }
            catch (Exception ex)
            {
                IdProductoGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdProductoGenerado;
        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                 CREATE PROC sp_ModificarProducto(
                     @IdProducto INT,
                     @Codigo VARCHAR (20),
                     @Nombre VARCHAR (30),
                     @Descripcion VARCHAR (50),
                     @IdCategoria INT,
                     @IdMarca INT,
                     @Estado BIT,
                     @Resultado BIT OUTPUT,
                     @Mensaje VARCHAR (500) OUTPUT)
                */
                datos.setearConsulta("sp_ModificarProducto", true);
                datos.setearParametros("@IdProducto", obj.IdProducto);
                datos.setearParametros("@Codigo", obj.Codigo);
                datos.setearParametros("@Nombre", obj.Nombre);
                datos.setearParametros("@Descripcion", obj.Descripcion);
                datos.setearParametros("@IdCategoria", obj.oCategoria.Id);
                datos.setearParametros("@IdMarca", obj.oMarca.Id);
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

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*
                  CREATE PROC sp_EliminarProducto(
                    @IdProducto INT,
                    @Respuesta BIT OUTPUT,
                    @Mensaje VARCHAR (500) OUTPUT)
                */

                datos.setearConsulta("sp_EliminarProducto", true);
                datos.setearParametros("@IdProducto", obj.IdProducto);
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
