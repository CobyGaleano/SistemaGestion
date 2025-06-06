using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class RolNegocio
    {
        public List<Rol> Listar()
        {
            
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IdRol, Descripcion from ROL");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Rol()
                    {
                        IdRol = Convert.ToInt32(datos.Lector["IdRol"]) ,
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                lista = new List<Rol>();
                return lista;
            }
        }
    }
}
