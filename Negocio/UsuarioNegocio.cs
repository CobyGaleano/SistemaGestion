using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

using System.Data;
using System.Data.SqlClient;


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
    }

}
