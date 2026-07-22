using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Datos {
    public class DaoPaciente {
        private readonly AccesoDatos objAccesoDatos = new AccesoDatos();
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

                    P.Estado,

                    PR.Nombre AS Provincia,
                    LO.Nombre AS Localidad
                FROM PACIENTE P
                INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad");
        }

        public bool existeDNI(String dni) {

            string existe = "SELECT DNI FROM PACIENTE WHERE DNI = @dni AND Estado = 1";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@dni", dni) };

            DataTable dt = objAccesoDatos.ejecutarConsulta(existe, parametros);

            return dt.Rows.Count > 0;
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

        //BUSQUEDAS

        public DataTable filtrarPorDni(string dni) {
            string consulta = @"SELECT
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

                                P.Estado,

                                PR.Nombre AS Provincia,
                                LO.Nombre AS Localidad
                            FROM PACIENTE P
                            INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                            INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad
                            WHERE P.DNI LIKE '%' + @DNI + '%'";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@DNI", dni) };

            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }

        public DataTable filtrarPorNombre(string nombre) {
            string consulta = @"SELECT
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

                                P.Estado,

                                PR.Nombre AS Provincia,
                                LO.Nombre AS Localidad
                            FROM PACIENTE P
                            INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                            INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad
                            WHERE (P.Nombre LIKE '%' + @Busqueda + '%')";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Busqueda", nombre) };

            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }

        public DataTable filtrarPorApellido(string apellido) {
            string consulta = @"SELECT
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

                                P.Estado,

                                PR.Nombre AS Provincia,
                                LO.Nombre AS Localidad
                            FROM PACIENTE P
                            INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                            INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad
                            WHERE (P.Apellido LIKE '%' + @Busqueda + '%')";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Busqueda", apellido) };

            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }

        //FILTROS

        public DataTable filtrarPorSexo(string sexo) {
            string consulta = @"SELECT
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

                                P.Estado,

                                PR.Nombre AS Provincia,
                                LO.Nombre AS Localidad
                            FROM PACIENTE P
                            INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                            INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad
                            WHERE Sexo = @Sexo";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Sexo", sexo) };

            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
        }
        public DataTable filtrarPorEstado(int estado) {
            if (estado == 1 || estado == 0) { 
                string consulta = @"SELECT
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

                                P.Estado,

                                PR.Nombre AS Provincia,
                                LO.Nombre AS Localidad
                            FROM PACIENTE P
                            INNER JOIN PROVINCIA PR ON P.IdProvincia = PR.IdProvincia
                            INNER JOIN LOCALIDAD LO ON P.IdLocalidad = LO.IdLocalidad
                            WHERE Estado = @Estado";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Estado", estado) };

            return objAccesoDatos.ejecutarConsulta(consulta, parametros);
            } else {
                return getTodos();
            }
        }
    }
}
