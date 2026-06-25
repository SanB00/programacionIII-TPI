using Entidades;
using System.Data;
using System.Data.SqlClient;

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

        public bool agregarPaciente(Paciente nuevo) {

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@dni", nuevo.getDni());
            cmd.Parameters.AddWithValue("@nombre", nuevo.getNombre());
            cmd.Parameters.AddWithValue("@apellido", nuevo.getApellido());
            cmd.Parameters.AddWithValue("@sexo", nuevo.getSexo());
            cmd.Parameters.AddWithValue("@nacionalidad", nuevo.getNacionalidad());
            cmd.Parameters.AddWithValue("@fecha", nuevo.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@direccion", nuevo.getDireccion());
            cmd.Parameters.AddWithValue("@correo", nuevo.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@telefono", nuevo.getTelefono());
            cmd.Parameters.AddWithValue("@provincia", nuevo.getIdProvincia());
            cmd.Parameters.AddWithValue("@localidad", nuevo.getIdLocalidad());

            int filas = objAccesoDatos.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarPaciente");

            return filas > 0;
        }
    }
}
