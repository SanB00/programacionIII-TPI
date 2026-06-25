using Datos;
using System.Data;

namespace Negocio {
    public class NegocioPaciente {

        DaoPaciente objDaoPaciente = new DaoPaciente();

        public DataTable getTodosPacientes() {
            return objDaoPaciente.getTodos();
        }
                
    }
}
