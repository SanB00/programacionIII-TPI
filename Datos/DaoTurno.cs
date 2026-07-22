using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class DaoTurno {
        AccesoDatos objAccesoDatos = new AccesoDatos();

        public bool agregarTurno(Turno t) {
            if (t.getLegajo() == 0 ||
                string.IsNullOrWhiteSpace(t.getDniPaciente()) ||
                string.IsNullOrWhiteSpace(t.getFecha())) {
                return false;
            }

            if (existeTurnoMedico(t.getLegajo(), t.getFecha(), t.getHorarioInicio())) {
                return false;
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@legajo", t.getLegajo());
            cmd.Parameters.AddWithValue("@dni", t.getDniPaciente());
            cmd.Parameters.AddWithValue("@fecha", t.getFecha());
            cmd.Parameters.AddWithValue("@horarioInicio", t.getHorarioInicio());

            int filas = objAccesoDatos.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarTurno");

            return filas > 0;
        }

        public DataTable getTurnosPorMedico(int legajo) {
            string consulta = @"SELECT 
                                T.IdTurno,
                                P.Nombre + ' ' + P.Apellido AS Paciente,
                                T.Fecha,
        
                                T.HorarioInicio AS Horario,

                                CASE 
                                    WHEN T.Asistencia = 1 THEN 'Presente'
                                    WHEN T.Asistencia = 0 THEN 'Ausente'
                                    ELSE 'Sin marcar'
                                END AS Asistencia,

                                T.Observacion

                            FROM TURNO T
                            INNER JOIN PACIENTE P 
                                ON T.DNI = P.DNI

                            WHERE T.Legajo = @legajo 
                                AND T.Estado = 1

                            ORDER BY T.Fecha ASC";
            SqlParameter[] parametros = { new SqlParameter("@legajo", legajo) };
            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }

        public bool existeTurnoMedico(int legajo, string fecha, int horarioInicio) {
            string consulta = "SELECT 1 FROM TURNO WHERE Legajo = @legajo AND Fecha = @fecha AND HorarioInicio = @horarioInicio";

            SqlParameter[] parametros = new SqlParameter[]
            {
             new SqlParameter("@legajo", legajo), new SqlParameter("@fecha", fecha), new SqlParameter("@horarioInicio", horarioInicio) };

            DataTable tabla = objAccesoDatos.ejecutarConsulta(consulta, parametros);

            return tabla.Rows.Count > 0;
        }
        public bool actualizarTurno(int idTurno, bool asistencia, string observacion) {
            string consulta = @"
                                UPDATE TURNO
                                SET 
                                    Asistencia = @asistencia,
                                    Observacion = @observacion
                                WHERE IdTurno = @idTurno";

            SqlParameter[] parametros = new SqlParameter[] {new SqlParameter("@idTurno", idTurno),new SqlParameter("@asistencia", asistencia),new SqlParameter("@observacion", observacion)};

            int filasAfectadas = objAccesoDatos.ejecutarAccion(consulta, parametros);

            return filasAfectadas > 0;
        }
    }
}
