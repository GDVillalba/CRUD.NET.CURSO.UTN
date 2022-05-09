using CRUDNETBDD.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDNETBDD.Datos
{
    public class ClientesDatos
    {
        //Read
        public List<ModelCliente> Listar()
        {
            var oLista = new List<ModelCliente>();
            //Conexion
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Listar", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ModelCliente()
                        {

                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["nombre"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                            Poblacion = dr["poblacion"].ToString(),
                            Telefono = dr["telefono"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        //Read by Id
        public ModelCliente Obtener(int id)
        {
            var oCliente = new ModelCliente();
            //Conexion
            var cn = new Conexion();

            using (var conexion = new SqlConnection( cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obtener", conexion);
                cmd.Parameters.AddWithValue("IdCliente", id);//Recibe el parametro
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oCliente.Id = Convert.ToInt32(dr["Id"]);
                        oCliente.Nombre = dr["nombre"].ToString();
                        oCliente.Direccion = dr["direccion"].ToString();
                        oCliente.Poblacion = dr["poblacion"].ToString();
                        oCliente.Telefono = dr["telefono"].ToString();
                    }
                }

            }

            return oCliente;
        }

        //Create
        public bool Guardar(ModelCliente oCliente)
        {
            bool respuesta = false;

            try
            {
                var cn = new Conexion();
                using (var Conexion = new SqlConnection( cn.getCadenaSQL() ))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", Conexion );
                    //cmd.Parameters.AddWithValue("Id", oCliente.Id);
                    cmd.Parameters.AddWithValue("nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("poblacion", oCliente.Poblacion);
                    cmd.Parameters.AddWithValue("telefono", oCliente.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                }

                respuesta = true;

            }catch (Exception ex)
            {
                string error = ex.Message;
                respuesta= false;
            }

            return respuesta;
        }

    }
}
