using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class DaoUsuario {
        public string validarUsuario(string usuario, string contrasenia) {
            AccesoDatos acceso = new AccesoDatos();

            string consulta =
                @"SELECT *
                  FROM USUARIO
                  WHERE NombreUsuario = @usuario
                  AND Contrasena = @contrasenia";

            SqlParameter[] parametros =
            {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasenia", contrasenia)
            };

            DataTable dt = acceso.ejecutarConsulta(consulta, parametros);

            if (dt.Rows.Count > 0) {
                return dt.Rows[0]["TipoUsuario"].ToString();
            } else {
                return null;
            }
        }
    }
}
