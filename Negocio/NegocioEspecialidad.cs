using Datos;
using System.Data;

namespace Negocio {
    public class NegocioEspecialidad {
        DaoEspecialidad daoEspecialidad = new DaoEspecialidad();

        public DataTable getTodos() {
            return daoEspecialidad.getTodos();
        }
    }
}