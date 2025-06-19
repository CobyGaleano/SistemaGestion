using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public SqlCommand Comando
        {
            get { return comando;}
        }

        public AccesoDatos()
        {
            //ELIAS:
            //conexion = new SqlConnection("server=.\\SQLEXPRESSLAB3; database=CATALOGO_P3_DB; integrated security=false; user = sa; password = 123456");
            //BRIAN: 
            //conexion = new SqlConnection("server=.\\SQLLABO3; database=CATALOGO_P3_DB; integrated security=false; user = sa; password = 123456");
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=DBSISTEMA_VENTA; integrated security=false; user = sa; password = 123456");
            //JOAQUIN:
            //conexion = new SqlConnection("server=.\\SQLEXPRESS01; database=CATALOGO_P3_DB; integrated security=true ");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta, bool esProcedimiento = false)
        {
            comando.CommandType = esProcedimiento ? CommandType.StoredProcedure : CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(lector != null) 
            {
                lector.Close();
                conexion.Close();    
            }
        }


        public void setearParametros(string nombre, object valor) //setear parametros CON valores
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void setearParametroSalida(string nombre, SqlDbType tipo, int tamanio = 0)
        {
            SqlParameter parametroSalida = new SqlParameter(nombre, tipo);
            parametroSalida.Direction = ParameterDirection.Output;

            if (tamanio > 0)
                parametroSalida.Size = tamanio;

            comando.Parameters.Add(parametroSalida);
        }

        public object obtenerValorParametro(string nombre)
        {
            return comando.Parameters[nombre].Value;
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
