﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class articuloNegocio
    {
        public List<Articulo> listar()
        {
            //hola 
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdMarca, A.IdCategoria, I.idArticulo, I.ImagenUrl from ARTICULOS A, IMAGENES I where I.idArticulo = A.Id");
                //datos.setearConsulta("SELECT DISTINCT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion Marca, C.Descripcion Categoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                datos.setearConsulta("SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria, A.IdCategoria, A.IdMarca from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria\r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.imagenes = new List<Imagen>();
                    aux.imagenes = this.cargarImagenes(aux.Id);
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    /*if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.categoria.Descripcion = " ";
                    }
                    else
                    {
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }*/
                    aux.marca = new Marca();
                    aux.marca.Id = (int)datos.Lector["IdMarca"];
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /*public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT into ARTICULOS(Codigo, Nombre, Descripcion, Precio) values('"+ nuevo.Codigo +"', '"+ nuevo.Nombre +"', '"+ nuevo.Descripcion +"', " + nuevo.Precio +" )");
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            
        }*/
        //Joaquin
        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) values(@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio);SELECT SCOPE_IDENTITY() AS ID;");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@IdMarca", nuevo.marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.categoria.Id);
                datos.setearParametros("@Precio", nuevo.Precio);

                // datos.ejecutarAccion();

                nuevo.Id = Convert.ToInt32(datos.ejecutarScalar());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public void modificar(Articulo obj)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria WHERE ID = @Id");
                datos.setearParametros("@Codigo", obj.Codigo);
                datos.setearParametros("@Nombre", obj.Nombre);
                datos.setearParametros("@Precio", obj.Precio);
                datos.setearParametros("@Descripcion", obj.Descripcion);
                datos.setearParametros("@IdMarca", obj.marca.Id);
                datos.setearParametros("@IdCategoria", obj.categoria.Id);
                datos.setearParametros("@Id", obj.Id);

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
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       


        //Busqueda por distintos criterios
        public List<Articulo> Filtrar(string campo,string criterio,string filtro)
        {
            List<Articulo> lista= new List<Articulo>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, A.Precio, A.Codigo,A.Nombre, A.Descripcion, M.Descripcion Marca ,C.Descripcion Categoria from ARTICULOS A inner join MARCAS M on M.Id=A.IdMarca inner join CATEGORIAS C on C.Id=A.IdCategoria and ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a: ":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a: ":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }

                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "Nombre like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "Nombre like '%" + filtro + "%' ";
                                break;

                        }

                        break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con: ":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con: ":
                                consulta += "A.Descripcion like '%" + filtro + "' ";
                                break;
                            case "Contiene: ":
                                consulta += "A.Descripcion like '%" + filtro + "%' ";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.imagen = new Imagen();
                    aux.imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.categoria.Descripcion = " ";
                    }
                    else
                    {
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Busca un solo articulo
        public Articulo buscar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Codigo,A.Nombre,A.Descripcion,C.Descripcion Categoria,M.Descripcion Marca,A.Precio from ARTICULOS A , CATEGORIAS C , MARCAS M where A.IdCategoria=C.Id and A.IdMarca=M.Id and A.Id= @id ");
                datos.setearParametros("id", id);
                datos.ejecutarLectura();

                datos.Lector.Read();

                Articulo seleccionado = new Articulo();
                seleccionado.Codigo = (string)datos.Lector["Codigo"];
                seleccionado.Nombre = (string)datos.Lector["Nombre"];
                seleccionado.Descripcion = (string)datos.Lector["Descripcion"];
                seleccionado.categoria = new Categoria();
                seleccionado.categoria.Descripcion = (string)datos.Lector["Categoria"];
                seleccionado.marca = new Marca();
                seleccionado.marca.Descripcion = (string)datos.Lector["Marca"];
                seleccionado.Precio = (decimal)datos.Lector["Precio"];
                
                return seleccionado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Imagen> cargarImagenes(int id)
        {
            List<Imagen> listaImg = new List<Imagen>();
            List<Imagen> listaImg2 = new List<Imagen>();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                listaImg = imagenNegocio.listar();

                foreach (Imagen item in listaImg)
                {
                    if (item.IdArticulo == id)
                    {
                        listaImg2.Add(item);
                    }
                }

                return listaImg2;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
                                         