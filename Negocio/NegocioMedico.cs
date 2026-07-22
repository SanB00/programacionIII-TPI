using Datos;
using Entidades; 
using System;
using System.Data;

namespace Negocio {
    public class NegocioMedico {
        
        DaoMedico daoMedico = new DaoMedico();

        //FUNCIONES BASICAS
        public DataTable getTodos() {
            return daoMedico.getTodos();
        }
        public bool agregarMedico(Medico nuevo) {
            return daoMedico.agregarMedico(nuevo);
        }

        public bool actualizarMedico(Medico nuevoDatos) {
            return daoMedico.actualizarMedico(nuevoDatos);
        }
        
        public DataTable obtenerTablaMedicos() {
            return daoMedico.obtenerTablaMedicos();
        }
        public DataTable getTodosPorEspecialidad(int idEspecialidad) {
            return daoMedico.getTodosPorEspecialidad(idEspecialidad);
        }

        //FUNCIONES DE CONSULTAS
        public bool existeDNI(String dni) {
            return daoMedico.existeDNI(dni);
        }
        public bool existeUsuario(string usuario) {
            return daoMedico.existeUsuario(usuario);
        }
        public int getLegajoPorUsuario(string nombreUsuario) {
            return daoMedico.getLegajoPorUsuario(nombreUsuario);
        }

        //BUSQUEDAS
        public DataTable filtrarPorLegajo(int legajo) {
            return daoMedico.filtrarPorLegajo(legajo);
        }

        public DataTable filtrarPorApellido(string busqueda) {
            return daoMedico.filtrarPorApellido(busqueda);
        }

        public DataTable filtrarPorNombre(string busqueda) {
            return daoMedico.filtrarPorNombre(busqueda);
        }

        //FILTROS

        public DataTable filtrarPorSexo(string sexo) {
            return daoMedico.filtrarPorSexo(sexo);
        }

        public DataTable filtrarPorEstado(int estado) {
            return daoMedico.filtrarPorEstado(estado);
        }

        public DataTable filtrarPorEspecialidad(string especialidad) {
            return daoMedico.filtrarPorEspecialidad(especialidad);
        }

    }
}
