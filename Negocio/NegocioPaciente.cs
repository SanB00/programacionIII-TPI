using Datos;
using Entidades;
using System.Data;

namespace Negocio {
    public class NegocioPaciente {
        private readonly DaoPaciente objDaoPaciente = new DaoPaciente();
        public NegocioPaciente() { }
        public DataTable getTodosPacientes() {
            return objDaoPaciente.getTodos();
        }

        public bool agregarPaciente(Paciente obj) {
            return objDaoPaciente.agregarPaciente(obj);
        }

        public bool actualizarPaciente(Paciente obj) {
            return objDaoPaciente.actualizarPaciente(obj);
        }
    }
}
