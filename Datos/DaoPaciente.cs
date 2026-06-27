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

            P.IdProvincia,
            P.IdLocalidad,

            CASE
                WHEN P.Estado = 1 THEN 'Activo'
                ELSE 'Inactivo'
            END AS Estado,

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

            if (filas > 0) {
                return true;
            } else {
                return false;
            }
        }
        public bool actualizarPaciente(Paciente datosNuevos) {

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@DNI", datosNuevos.getDni());
            cmd.Parameters.AddWithValue("@Nombre", datosNuevos.getNombre());
            cmd.Parameters.AddWithValue("@Apellido", datosNuevos.getApellido());
            cmd.Parameters.AddWithValue("@Sexo", datosNuevos.getSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad", datosNuevos.getNacionalidad());
            cmd.Parameters.AddWithValue("@FechaNacimiento", datosNuevos.getFechaNacimiento());
            cmd.Parameters.AddWithValue("@Direccion", datosNuevos.getDireccion());
            cmd.Parameters.AddWithValue("@CorreoElectronico", datosNuevos.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono", datosNuevos.getTelefono());
            cmd.Parameters.AddWithValue("@IdProvincia", datosNuevos.getIdProvincia());
            cmd.Parameters.AddWithValue("@IdLocalidad", datosNuevos.getIdLocalidad());
            cmd.Parameters.AddWithValue("@Estado", datosNuevos.getEstado());

            int filas = objAccesoDatos.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarPaciente");

            if (filas > 0) {
                return true;
            } else {
                return false;
            }
        }

    }
}
