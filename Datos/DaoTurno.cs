using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class DaoTurno {
        AccesoDatos objAccesoDatos = new AccesoDatos();

        public bool agregarTurno(Turno t) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@legajo", t.getLegajo());
            cmd.Parameters.AddWithValue("@dni", t.getDniPaciente());
            cmd.Parameters.AddWithValue("@fecha", t.getFecha());
            cmd.Parameters.AddWithValue("@horarioInicio", t.getHorarioInicio());
            int filas = objAccesoDatos.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarTurno");
            return filas > 0;
        }

        public DataTable getTurnosPorMedico(int legajo) {
            string consulta = @"SELECT T.IdTurno,
                                       P.Nombre + ' ' + P.Apellido AS Paciente,
                                       T.Fecha,
                                       T.HorarioInicio AS Horario,
                                       CASE WHEN T.Asistencia = 1 THEN 'Presente'
                                            WHEN T.Asistencia = 0 THEN 'Ausente'
                                            ELSE 'Sin marcar' END AS Asistencia,
                                       T.Observacion
                               FROM TURNO T
                               INNER JOIN PACIENTE P ON T.DNI = P.DNI
                               WHERE T.Legajo = @legajo AND T.Estado = 1
                               ORDER BY T.Fecha DESC";
            SqlParameter[] parametros = { new SqlParameter("@legajo", legajo) };
            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }
    }
}
