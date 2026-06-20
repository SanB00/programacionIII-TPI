using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class AccesoDatos {
        private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True";
        //private string CADENA_CONEXION = @"Data Source=localhost\\sqlexpress;Initial Catalog=BDClinica;Integrated Security=True";
        // cadenaParaEntrega
        // 	    private const string CADENA_CONEXION = @"Data Source=localhost\\sqlexpress;Initial Catalog=BDClinica;Integrated Security=True";
        // 
        // Franco
        //      private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=localhost\sqlexpress;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        // 	 
        // Lautaro
        // 	    private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=localhost;Integrated Security=True;Trust Server Certificate=True";
        // 
        // Santi
        // 	    private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True";
        // 
        // Elian 
        // 	    private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=localhost;Integrated Security=True";
        //  
        // Yulieth 
        // 	    private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=DESKTOP-RFDMNU2\SQLEXPRESS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";			 	 
        // 	 
        // Guillermo
        // 	    private const string CADENA_CONEXION = @"Initial Catalog=BDClinica;Data Source=localhost;Integrated Security=True";

        public AccesoDatos() { }

        public SqlConnection obtenerConexion() {
            SqlConnection sqlConnection = new SqlConnection(CADENA_CONEXION);
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
            string connectionString = CADENA_CONEXION;
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
            string connectionString = CADENA_CONEXION;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);

            int filasAfectadas = sqlCommand.ExecuteNonQuery(); /// INSERT, UPDATE, DELETE

            sqlConnection.Close();
            return filasAfectadas;
        }
    }
}
