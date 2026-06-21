using System.Data;

namespace Datos {
    public class DaoPaciente {
        AccesoDatos objAccesoDatos = new AccesoDatos();
        public DataTable getTodos() {
            return objAccesoDatos.ejecutarConsulta(
                @"SELECT
            P.DNI,
            P.Nombre,
            P.Apellido,
            P.Sexo,
            P.Nacionalidad,
            P.FechaNacimiento,
            P.Direccion,
            P.CorreoElectronico,
            P.Telefono,
            PR.Nombre AS Provincia,
            LO.Nombre AS Localidad
          FROM PACIENTE P
          INNER JOIN PROVINCIA PR
            ON P.IdProvincia = PR.IdProvincia
          INNER JOIN LOCALIDAD LO
            ON P.IdLocalidad = LO.IdLocalidad");
        }
    }
}
