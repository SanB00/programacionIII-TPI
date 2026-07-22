using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocio {
    public class NegocioPaciente {

        DaoPaciente objDaoPaciente = new DaoPaciente();

        public DataTable getTodosPacientes() {
            return objDaoPaciente.getTodos();
        }
        public bool existeDNI(String dni) {
            return objDaoPaciente.existeDNI(dni);
        }
        public bool agregarPaciente(Paciente nuevo) {

            return objDaoPaciente.agregarPaciente(nuevo);
        }

        public bool actualizarPaciente(Paciente nuevoDatos) {
            return objDaoPaciente.actualizarPaciente(nuevoDatos);
        }

        //BUSQUEDAS

        public DataTable filtrarPorDni(string dni) {
            return objDaoPaciente.filtrarPorDni(dni);
        }

        public DataTable filtrarPorNombre(string nombre) {
            return objDaoPaciente.filtrarPorNombre(nombre);
        }

        public DataTable filtrarPorApellido(string apellido) {
            return objDaoPaciente.filtrarPorApellido(apellido);
        }

        //FILTROS
        public DataTable filtrarPorSexo(string sexo) {
            return objDaoPaciente.filtrarPorSexo(sexo);
        }
        public DataTable filtrarPorEstado(int estado) {
            return objDaoPaciente.filtrarPorEstado(estado);
        }

        
    }
}
