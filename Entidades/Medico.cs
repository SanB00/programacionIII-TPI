using System;

namespace Entidades {
    public class Medico : Persona {
        private String legajo;
        private String especialidad;
        private String diasAtencion;
        private String horarioAtencion;          

        //Getters
        public string getLegajo() {
            return this.legajo;
        }
        public string getEspecialidad() {
            return this.especialidad;
        }
        public String getDiasAtencion() {
            return this.diasAtencion;
        }
        public String getHorarioAtencion() {
            return this.horarioAtencion;
        }

        //Setters

        public void setLegajo(string legajo) {
            this.legajo = legajo;
        }
        public void setEspecialidad(string especialidad) {
            this.especialidad = especialidad;
        }
        public void setDiasAtencion(String diasAtencion) {
            this.diasAtencion = diasAtencion;
        }
        public void setHorarioAtencion(string horarioAtencion) { 
            this.horarioAtencion = horarioAtencion;
        }

    }
}

