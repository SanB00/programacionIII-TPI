using Datos;
using Entidades;
using System.Data;

namespace Negocio {
    public class NegocioPaciente {

        DaoPaciente objDaoPaciente = new DaoPaciente();

        public DataTable getTodosPacientes() {
            return objDaoPaciente.getTodos();
        }

        public bool agregarPaciente(Paciente nuevo) {
            return objDaoPaciente.agregarPaciente(nuevo);
        }

        public bool actualizarPaciente(Paciente nuevoDatos) {
            return objDaoPaciente.actualizarPaciente(nuevoDatos);
        }
    }
}
