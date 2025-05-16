using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class PermisoNegocio
    {
        public List<Permiso> Listar(int idUsuario)
        {
            //hola 
            List<Permiso> lista = new List<Permiso>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select P.IdRol,P.NombreMenu from PERMISO P\r\ninner Join ROL R ON R.IdRol = P.IdRol\r\ninner Join USUARIO U on U.IdRol = R.IdRol\r\nwhere U.IdUsuario = @idUsuario");
                datos.setearParametros("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Permiso()
                    {
                        oRol = new Rol() { IdRol = Convert.ToInt32(datos.Lector["IdRol"]) },
                        NombreMenu = datos.Lector["NombreMenu"].ToString(),
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                lista = new List<Permiso>();
                return lista;
            }
        }
    }
}
