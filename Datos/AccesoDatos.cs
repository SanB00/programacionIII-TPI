using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class AccesoDatos {
        // private string rutaBD = @"Data Source=localhost;Initial Catalog=BDClinica;Integrated Security=True";
        //Franco
        //private string rutaBD = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True";
        //Lauti
         private string rutaBD = @"Data Source=localhost;Initial Catalog=BDClinica;Integrated Security=True";
        // private string rutaBD = @"Data Source=DESKTOP-RFDMNU2\SQLEXPRESS;Initial Catalog=BDClinicaIntegrated Security=True;Encrypt=False;TrustServerCertificate=True";
         //private string rutaBD = @"Data Source =.\SQLEXPRESS;Initial Catalog = BDClinica; Integrated Security = True;";
         //Santiago
       // private string rutaBD = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDClinica;Integrated Security=True";
        public AccesoDatos() { }
         
        public SqlConnection obtenerConexion() {
            SqlConnection sqlConnection = new SqlConnection(rutaBD);
            try {
                sqlConnection.Open();
                return sqlConnection;
            } catch (Exception exception) {
                return null;
            }
        }
        public SqlDataAdapter obtenerAdaptador(string consultaSql) {
            SqlDataAdapter sqlDataAdapter;
            try {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, obtenerConexion());
                return sqlDataAdapter;
            } catch (Exception exception) {
                return null;
            }
        }

        public int ejecutarProcedimientoAlmacenado(SqlCommand comandoSQL, string nombreProcedimientoAlmacenado) {
            int filasCambiadas;
            SqlConnection conexion = obtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = nombreProcedimientoAlmacenado;
            filasCambiadas = sqlCommand.ExecuteNonQuery();
            return filasCambiadas;
        }

        public DataTable ejecutarConsulta(string consultaSQL, SqlParameter[] parametros = null) {
            string connectionString = rutaBD;
            DataTable dataTable = new DataTable();

            // El bloque 'using' asegura que la conexión se cierre SIEMPRE, incluso si hay error
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                try {
                    SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);
                    if (parametros != null) {
                        sqlCommand.Parameters.AddRange(parametros);
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                } catch (Exception e) {
                    throw new Exception($"Error al consultar la base de datos: \n{e.Message}");
                }
            }
            return dataTable;
        }
        public int ejecutarTransaccion(string consultaSQL) {
            string connectionString = rutaBD;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery(); /// INSERT, UPDATE, DELETE

            sqlConnection.Close();

            return filasAfectadas;
        }

        public Boolean existe(String consulta) {
            Boolean estado = false;
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read()) {
                estado = true;
            }
            return estado;
        }

        public int obtenerMaximo(String consulta) {
            int max = 0;
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read()) {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }
    }
}