using Datos;
using System.Data;

namespace Negocio {
    public class NegocioLocalidad {
        DaoLocalidad objDaoLocalidad = new DaoLocalidad();

        public DataTable getTodos() {
            return objDaoLocalidad.getTodos();
        }

        public DataTable getPorProvincia(int idProvincia) {
            return objDaoLocalidad.getPorProvincia(idProvincia);
        }
    }
}