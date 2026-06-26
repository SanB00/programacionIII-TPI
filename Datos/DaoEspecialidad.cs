using System.Data;

namespace Datos {
    public class DaoEspecialidad {
        AccesoDatos objAccesoDatos = new AccesoDatos();

        public DataTable getTodos() {
            return objAccesoDatos.ejecutarConsulta("SELECT IdEspecialidad, Nombre FROM ESPECIALIDAD");
        }
    }
}