using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Datos {
    public class DaoMedico {
        public bool agregarMedico(Medico objMedico) {
            AccesoDatos conexion = new AccesoDatos();
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
            cmd.Parameters.AddWithValue("@NombreUsuario", objMedico.getUsuario());
            cmd.Parameters.AddWithValue("@Contrasena", objMedico.getContrasena());

            int filasAfectadas = conexion.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarMedico");
            
            return filasAfectadas > 0;
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
        public DataTable getTodos() {
            AccesoDatos conexion = new AccesoDatos();
            return conexion.ejecutarConsulta(
                @"SELECT M.Legajo, M.Nombre + ' ' + M.Apellido AS NombreMedico,
                         E.Nombre AS NombreEspecialidad
                  FROM MEDICO M
                  INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad
                  WHERE M.Estado = 1");
        }

        public DataTable obtenerTablaMedicos() {
            AccesoDatos conexion = new AccesoDatos();

            string consulta = "SELECT M.Legajo, M.DNI, M.Nombre, M.Apellido, E.Nombre AS Especialidad,M.DiasAtencion as Dias,M.HorarioAtencion as Horario " +
                  "FROM MEDICO M " +
                  "INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad " +
                  "WHERE M.Estado = 1";

            SqlConnection cn = conexion.obtenerConexion();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            return tabla;
        }

        public DataTable filtrarPorLegajo(int legajo) {
            AccesoDatos conexion = new AccesoDatos();

            string consulta = "SELECT M.Legajo, M.DNI, M.Nombre, M.Apellido, E.Nombre AS Especialidad,M.DiasAtencion as Dias,M.HorarioAtencion as Horario " +
                 "FROM MEDICO M " +
                 "INNER JOIN ESPECIALIDAD E ON M.IdEspecialidad = E.IdEspecialidad " +
                 "WHERE M.Legajo = @legajo AND M.Estado = 1";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@legajo", legajo)
            };

            return conexion.ejecutarConsulta(consulta, parametros);
        }
        public DataTable getTodosPorEspecialidad(int idEspecialidad) {
            AccesoDatos conexion = new AccesoDatos();
            string consulta = @"SELECT M.Legajo, M.Nombre + ' ' + M.Apellido AS NombreMedico
                        FROM MEDICO M
                        WHERE M.IdEspecialidad = @idEspecialidad AND M.Estado = 1";
            SqlParameter[] parametros = { new SqlParameter("@idEspecialidad", idEspecialidad) };
            return conexion.ejecutarConsulta(consulta, parametros);
        }

    }
}
