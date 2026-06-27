using System;

namespace Entidades {
    public class Medico : Persona {
        private String legajo;
        private int idEspecialidad;
        private String diasAtencion;
        private String horarioAtencion;          

        //Getters
        public String getLegajo() {
            return this.legajo;
        }
        public int getIdEspecialidad() {
            return this.idEspecialidad;
        }
        public String getDiasAtencion() {
            return this.diasAtencion;
        }
        public String getHorarioAtencion() {
            return this.horarioAtencion;
        }

        //Setters

        public void setLegajo(String legajo) {
            this.legajo = legajo;
        }
        public void setIdEspecialidad(int especialidad) {
            this.idEspecialidad = especialidad;
        }
        public void setDiasAtencion(String diasAtencion) {
            this.diasAtencion = diasAtencion;
        }
        public void setHorarioAtencion(string horarioAtencion) { 
            this.horarioAtencion = horarioAtencion;
        }

    }
}

