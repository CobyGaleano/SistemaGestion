using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioNegocio
    {
        public Dominio.Negocio ObtenerDatos()
        {
            Dominio.Negocio obj = new Dominio.Negocio();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("SELECT IdNegocio, Nombre, RUC, Direccion FROM NEGOCIO WHERE IdNegocio = @IdNegocio");
                //datos.setearParametros("@IdNegocio", obj.IdNegocio);
                datos.setearConsulta("SELECT IdNegocio, Nombre, RUC, Direccion FROM NEGOCIO WHERE IdNegocio = 1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    obj = new Dominio.Negocio()
                    {
                        IdNegocio = Convert.ToInt32(datos.Lector["IdNegocio"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        RUC = datos.Lector["RUC"].ToString(),
                        Direccion = datos.Lector["Direccion"].ToString()
                    };

                }
            }
            catch
            {
                obj = new Dominio.Negocio();
            }


            return obj;
        }

        public bool GuardarDatos(Dominio.Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("SELECT IdNegocio, Nombre, RUC, Direccion FROM NEGOCIO WHERE IdNegocio = @IdNegocio");
                //datos.setearParametros("@IdNegocio", obj.IdNegocio);
                datos.setearConsulta("UPDATE NEGOCIO SET Nombre = @Nombre, RUC = @RUC, Direccion = @Direccion WHERE IdNegocio = 1");
                datos.setearParametros("@Nombre", obj.Nombre);
                datos.setearParametros("@RUC", obj.RUC);
                datos.setearParametros("@Direccion", obj.Direccion);

                if (!datos.ejecutarAccionResultado())
                {
                    mensaje = "No se pudo guardar los datos";
                    respuesta = false;
                }

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }


            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Logo FROM NEGOCIO WHERE IdNegocio = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    LogoBytes = (byte[])datos.Lector["Logo"];
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }
            return LogoBytes;
        }

        public bool ActualizarLogo (byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = false;
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setearConsulta("UPDATE NEGOCIO SET Image = @Image WHERE IdNegocio = 1");
                datos.setearParametros("@Image", image);

                if (!datos.ejecutarAccionResultado())
                {
                    mensaje = "No se Actualizar el loco";
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
