using System.Data;

namespace Datos {
    public class DaoProvincia {
        AccesoDatos objAccesoDatos = new AccesoDatos();
        public DataTable getTodos() {
            return objAccesoDatos.ejecutarConsulta("SELECT * FROM Provincia ORDER BY nombre");
        }
    }
}
