using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class DaoUsuario {
        
        AccesoDatos acceso = new AccesoDatos();
        public string validarUsuario(string usuario, string contrasenia) {

            string consulta =
                 @"SELECT U.TipoUsuario
                    FROM USUARIO U
                    LEFT JOIN MEDICO M
                        ON U.IdUsuario = M.IdUsuario
                    WHERE U.NombreUsuario = @usuario
                      AND U.Contrasena = @contrasenia
                      AND (U.TipoUsuario = 'Administrador' OR M.Estado = 1)";

            SqlParameter[] parametros ={new SqlParameter("@usuario", usuario),new SqlParameter("@contrasenia", contrasenia)};

            DataTable dt = acceso.ejecutarConsulta(consulta, parametros);

            if (dt.Rows.Count > 0) {
                return dt.Rows[0]["TipoUsuario"].ToString();
            } else {
                return null;
            }
        }

        public DataTable buscarPorLegajo(int legajo) {

            string consulta =
                @"SELECT
                    M.Legajo,
                    U.NombreUsuario,
                    U.Contrasena
                  FROM MEDICO M
                  INNER JOIN USUARIO U ON M.IdUsuario = U.IdUsuario
                  WHERE M.Legajo = @legajo";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@legajo", legajo);
            SqlDataAdapter adaptador = acceso.obtenerAdaptadorConComandSql(cmd);
            DataTable tabla = new DataTable();
            
            if (adaptador != null) {
                adaptador.Fill(tabla);
            }

            return tabla;

        }

        public bool actualizarUsuario(Usuario objUsuario) {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@legajo", objUsuario.getLegajo());
            cmd.Parameters.AddWithValue("@NombreUsuario", objUsuario.getNombreUsuario());
            cmd.Parameters.AddWithValue("@Contrasena", objUsuario.getContrasenia());

            int filasAfectadas = acceso.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarUsuario");

            if (filasAfectadas > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
