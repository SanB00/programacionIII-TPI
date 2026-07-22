using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class AccesoDatos {
        //private string rutaBD = @"Data Source=localhost;Initial Catalog=BDClinica;Integrated Security=True";
        //Franco
        //private string rutaBD = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True";
        //Lauti
        //private string rutaBD = @"Data Source=localhost;Initial Catalog=BDClinica;Integrated Security=True";ENTREGA
        // Santi
        private string rutaBD = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDClinica;Integrated Security=True";
        // Elian
        //private string rutaBD = @"Data Source=DESKTOP-6K4PVV3\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True";
        //Guille
        //private string rutaBD = @"Data Source=DESKTOP-OJ9ACIL\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True";
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

        public SqlDataAdapter obtenerAdaptadorConComandSql(SqlCommand comandoSQL) {
            
            SqlConnection conexion = obtenerConexion();

            comandoSQL.Connection = conexion;

            return new SqlDataAdapter(comandoSQL);
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
            conexion.Close();
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

        public int ejecutarAccion(string consultaSQL, SqlParameter[] parametros = null) {
            using (SqlConnection sqlConnection = new SqlConnection(rutaBD)) {
                try {SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);

                    if (parametros != null) {
                        sqlCommand.Parameters.AddRange(parametros);
                    }

                    sqlConnection.Open();

                    return sqlCommand.ExecuteNonQuery();
                } catch (Exception e) {
                    throw new Exception($"Error al ejecutar la consulta: \n{e.Message}");
                }
            }
        }
    }
}