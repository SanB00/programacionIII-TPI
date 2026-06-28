using System;
using Entidades; 
using Datos;

namespace Negocio {
    public class NegocioMedico {
        
        DaoMedico daoMedico = new DaoMedico();
        public System.Data.DataTable getTodos() {
            return daoMedico.getTodos();
        }
        public bool registrarMedico(Medico objMedico) {
            if (string.IsNullOrWhiteSpace(objMedico.getDni())
                || string.IsNullOrWhiteSpace(objMedico.getNombre())
                || string.IsNullOrWhiteSpace(objMedico.getApellido())
                || string.IsNullOrWhiteSpace(objMedico.getLegajo())
                || string.IsNullOrWhiteSpace(objMedico.getDiasAtencion())
                || string.IsNullOrWhiteSpace(objMedico.getHorarioAtencion())) 
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
}
}
