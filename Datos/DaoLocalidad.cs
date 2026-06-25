using Entidades;
using System.Data;

namespace Datos {
    public class DaoLocalidad {
        AccesoDatos objAccesoDatos = new AccesoDatos();

        public DataTable getTodos() {
            return objAccesoDatos.ejecutarConsulta("SELECT * FROM Localidad ORDER BY nombre");
        }

        public DataTable getPorProvincia(int idProvincia) {
            return objAccesoDatos.ejecutarConsulta(
                "SELECT * FROM Localidad WHERE IdProvincia = " + idProvincia + " ORDER BY nombre");
        }
    }
}