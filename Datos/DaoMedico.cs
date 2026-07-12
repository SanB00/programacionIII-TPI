using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Datos {
    public class DaoMedico {
        
        AccesoDatos conexion = new AccesoDatos();

        //FUNCIONES BASICAS
        public DataTable getTodos() {

            return conexion.ejecutarConsulta(
                @"SELECT M.Legajo, M.Nombre + ' ' + M.Apellido AS NombreMedico,
                         E.Nombre AS NombreEspecialidad
                  FROM MEDICO M
                  INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad
                  WHERE M.Estado = 1");
        }

        public bool agregarMedico(Medico objMedico) {

            SqlCommand cmd = new SqlCommand();
          
            cmd.Parameters.AddWithValue("@dni", objMedico.getDni());
            cmd.Parameters.AddWithValue("@nombre", objMedico.getNombre());
            cmd.Parameters.AddWithValue("@apellido", objMedico.getApellido());
            cmd.Parameters.AddWithValue("@sexo", objMedico.getSexo());
            cmd.Parameters.AddWithValue("@nacionalidad", objMedico.getNacionalidad());
            cmd.Parameters.AddWithValue("@FechaNacimiento", objMedico.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@direccion", objMedico.getDireccion());
            cmd.Parameters.AddWithValue("@idLocalidad", objMedico.getIdLocalidad());
            cmd.Parameters.AddWithValue("@idProvincia", objMedico.getIdProvincia());
            cmd.Parameters.AddWithValue("@CorreoElectronico", objMedico.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@telefono", objMedico.getTelefono());
            cmd.Parameters.AddWithValue("@idEspecialidad", objMedico.getIdEspecialidad());
            cmd.Parameters.AddWithValue("@diasAtencion", objMedico.getDiasAtencion());
            cmd.Parameters.AddWithValue("@horarioAtencion", objMedico.getHorarioAtencion());
            cmd.Parameters.AddWithValue("@NombreUsuario", objMedico.getUsuario());
            cmd.Parameters.AddWithValue("@Contrasena", objMedico.getContrasena());

            int filasAfectadas = conexion.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarMedico");

            if (filasAfectadas > 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool actualizarMedico(Medico objMedico) {
            
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@legajo", objMedico.getLegajo());
            cmd.Parameters.AddWithValue("@dni", objMedico.getDni());
            cmd.Parameters.AddWithValue("@nombre", objMedico.getNombre());
            cmd.Parameters.AddWithValue("@apellido", objMedico.getApellido());
            cmd.Parameters.AddWithValue("@sexo", objMedico.getSexo());
            cmd.Parameters.AddWithValue("@nacionalidad", objMedico.getNacionalidad());
            cmd.Parameters.AddWithValue("@FechaNacimiento", objMedico.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@direccion", objMedico.getDireccion());
            cmd.Parameters.AddWithValue("@idLocalidad", objMedico.getIdLocalidad());
            cmd.Parameters.AddWithValue("@idProvincia", objMedico.getIdProvincia());
            cmd.Parameters.AddWithValue("@CorreoElectronico", objMedico.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@telefono", objMedico.getTelefono());
            cmd.Parameters.AddWithValue("@idEspecialidad", objMedico.getIdEspecialidad());
            cmd.Parameters.AddWithValue("@diasAtencion", objMedico.getDiasAtencion());
            cmd.Parameters.AddWithValue("@horarioAtencion", objMedico.getHorarioAtencion());
            cmd.Parameters.AddWithValue("@Estado", objMedico.getEstado());
            

            int filasAfectadas = conexion.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarMedico");

            if (filasAfectadas > 0) {
                return true;
            } else {
                return false;
            }
        }

        public DataTable obtenerTablaMedicos() {

            string consulta =
              @"SELECT
                    M.Legajo,
                    M.DNI,
                    M.Nombre,
                    M.Apellido,
                    M.Sexo,
                    M.Nacionalidad,
                    M.FechaNacimiento,
                    M.Direccion,
                    M.CorreoElectronico,
                    M.Telefono,
                    M.IdProvincia,
                    P.Nombre AS Provincia,
                    M.IdLocalidad,
                    L.Nombre AS Localidad,
                    M.IdEspecialidad,
                    E.Nombre AS Especialidad,
                    M.DiasAtencion,
                    M.HorarioAtencion,
                    M.Estado
                FROM MEDICO M
                INNER JOIN PROVINCIA P ON M.IdProvincia = P.IdProvincia
                INNER JOIN LOCALIDAD L ON M.IdLocalidad = L.IdLocalidad
                INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad
                WHERE M.Estado = 1";

            SqlDataAdapter adaptador = conexion.obtenerAdaptador(consulta);
            DataTable tabla = new DataTable();

            if (adaptador != null) {
                adaptador.Fill(tabla);
            }

            return tabla;
        }

        public DataTable getTodosPorEspecialidad(int idEspecialidad) {

            string consulta = @"SELECT M.Legajo, M.Nombre + ' ' + M.Apellido AS NombreMedico
                        FROM MEDICO M
                        WHERE M.IdEspecialidad = @idEspecialidad AND M.Estado = 1";
            SqlParameter[] parametros = { new SqlParameter("@idEspecialidad", idEspecialidad) };
            return conexion.ejecutarConsulta(consulta, parametros);
        }
        
        //FUNCIONES DE CONSULTAS
        public bool existeDNI(String dni) {
            
            string existe = "SELECT DNI FROM MEDICO WHERE DNI = @dni AND Estado = 1";
            
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@dni", dni)};
            
            DataTable dt = conexion.ejecutarConsulta(existe, parametros);
            
            return dt.Rows.Count > 0;
        }

                public bool existeDNILegajo(String dni, int legajo) {
            AccesoDatos conexion = new AccesoDatos();
            string existe = "SELECT DNI FROM MEDICO WHERE (DNI = @dni OR Legajo = @legajo) AND Estado = 1";
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@dni", dni),
                new SqlParameter("@legajo", legajo)
            };
            
            DataTable dt = conexion.ejecutarConsulta(existe, parametros);
            
            return dt.Rows.Count > 0;
        }

        public bool existeUsuario(string usuario) {
            
            string consulta = "SELECT NombreUsuario FROM USUARIO WHERE NombreUsuario = @usuario";

            SqlParameter[] parametros = { new SqlParameter("@usuario", usuario)};

            DataTable dt = conexion.ejecutarConsulta(consulta, parametros);

            return dt.Rows.Count > 0;
        }

        public DataTable filtrarPorLegajo(int legajo) {

            string consulta = @"SELECT 
                                M.Legajo,
                                M.DNI,
                                M.Nombre,
                                M.Apellido,
                                M.Sexo,
                                M.Nacionalidad,
                                M.FechaNacimiento,
                                M.Direccion,
                                M.CorreoElectronico,
                                M.Telefono,
                                M.IdProvincia,
                                P.Nombre AS Provincia,
                                M.IdLocalidad,
                                L.Nombre AS Localidad,
                                M.IdEspecialidad,
                                E.Nombre AS Especialidad,
                                M.DiasAtencion,
                                M.HorarioAtencion,
                                M.Estado
                            FROM MEDICO M
                            INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad
                            INNER JOIN PROVINCIA P ON M.IdProvincia = P.IdProvincia
                            INNER JOIN LOCALIDAD L ON M.IdLocalidad = L.IdLocalidad
                            WHERE M.Legajo = @legajo AND M.Estado = 1";

            SqlParameter[] parametros = new SqlParameter[] {new SqlParameter("@legajo", legajo)};

            return conexion.ejecutarConsulta(consulta, parametros);
        }

        public int getLegajoPorUsuario(string nombreUsuario) {
            AccesoDatos conexion = new AccesoDatos();
            string consulta = @"SELECT M.Legajo
                         FROM MEDICO M
                         INNER JOIN USUARIO U ON M.IdUsuario = U.IdUsuario
                         WHERE U.NombreUsuario = @usuario AND M.Estado = 1";
            SqlParameter[] parametros = { new SqlParameter("@usuario", nombreUsuario) };

            DataTable dt = conexion.ejecutarConsulta(consulta, parametros);

            if (dt.Rows.Count > 0) {
                return Convert.ToInt32(dt.Rows[0]["Legajo"]);
            }
            return 0;
        }

    }
}
