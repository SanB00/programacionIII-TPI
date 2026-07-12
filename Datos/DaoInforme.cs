using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos {
    public class DaoInforme {
        AccesoDatos accesoDatos = new AccesoDatos();

        public DataTable obtenerAsistenciaPacientes(DateTime desde, DateTime hasta) {
            string consulta = @"
            SELECT
                T.Fecha,
                P.DNI,
                P.Apellido + ', ' + P.Nombre AS Paciente,
                M.Apellido + ', ' + M.Nombre AS Medico,
                CASE
                    WHEN T.Asistencia = 1 THEN 'Presente'
                    ELSE 'Ausente'
                END AS Asistencia
            FROM TURNO T
            INNER JOIN PACIENTE P
                ON T.DNI = P.DNI
            INNER JOIN MEDICO M
                ON T.Legajo = M.Legajo
            WHERE T.Fecha BETWEEN @Desde AND @Hasta
            ORDER BY T.Fecha";

            SqlParameter[] parametros =
            {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            return accesoDatos.ejecutarConsulta(consulta, parametros);
        }

        public DataTable obtenerTurnosPorEspecialidad(DateTime desde, DateTime hasta) {
            string consulta = @"
            SELECT
                E.Nombre AS Especialidad,
                COUNT(T.IdTurno) AS CantidadTurnos
            FROM TURNO T
            INNER JOIN MEDICO M
                ON T.Legajo = M.Legajo
            INNER JOIN ESPECIALIDAD E
                ON M.IdEspecialidad = E.IdEspecialidad
            WHERE T.Fecha BETWEEN @Desde AND @Hasta
            GROUP BY E.Nombre
            ORDER BY E.Nombre";

            SqlParameter[] parametros =
            {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            return accesoDatos.ejecutarConsulta(consulta, parametros);
        }
    }
}