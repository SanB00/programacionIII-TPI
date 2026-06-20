using Entidades;
using System.Data;

namespace Datos {
    public class DaoProvincia {
        AccesoDatos objAccesoDatos = new AccesoDatos();
        public DataTable getTodos() {
            return objAccesoDatos.ejecutarConsulta("SELECT * FROM Provincia ORDER BY nombre");
        }
        /*
        public Provincia getProvincia(Provincia prov) {
            DataTable tabla = dp.obtenerTabla("Provincia", "Select * from Provincia where Id_Provincia=" + prov.getIdProvincia());
            prov.setIdProvincia(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            prov.setDescripcionProvincia(tabla.Rows[0][1].ToString());
            return prov;
        }

        public Boolean existeProvincia(Provincia prov) {
            // String consulta = "Select * from Provincia where DescripcionProvincia='" + prov.getDescripcionProvincia() + "'";
            // return dp.existe(consulta);
            return false;
        }
        */

    }
}
