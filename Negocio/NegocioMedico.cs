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
        public DataTable filtrarPorLegajo(int legajo) {
            DaoMedico dao = new DaoMedico();
            return dao.filtrarPorLegajo(legajo);
        }
        public int getLegajoPorUsuario(string nombreUsuario) {
            return daoMedico.getLegajoPorUsuario(nombreUsuario);
        }
public bool registrarMedico(Medico objMedico) {
            if (string.IsNullOrWhiteSpace(objMedico.getDni())
                || string.IsNullOrWhiteSpace(objMedico.getNombre())
                || string.IsNullOrWhiteSpace(objMedico.getApellido())
                || string.IsNullOrWhiteSpace(objMedico.getLegajo())
                || string.IsNullOrWhiteSpace(objMedico.getDiasAtencion())
                || string.IsNullOrWhiteSpace(objMedico.getHorarioAtencion())
                || string.IsNullOrWhiteSpace(objMedico.getUsuario())
                || string.IsNullOrWhiteSpace(objMedico.getContrasena())
                ) 
                {
                return false;
            }
            int legajoInt = 0;
            int.TryParse(objMedico.getLegajo(), out legajoInt);

            if (daoMedico.existeDNILegajo(objMedico.getDni(), legajoInt)) {
                return false;
            }
            return daoMedico.agregarMedico(objMedico);
        }
        public DataTable getTodosPorEspecialidad(int idEspecialidad) {
            return daoMedico.getTodosPorEspecialidad(idEspecialidad);
        }

    }
}
