using System;

namespace Entidades {
    public class Medico : Persona {
        private String legajo;
        private int idEspecialidad;
        private String diasAtencion;
        private String horarioAtencion;
        private String usuario;
        private String contrasena;

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
        public String getUsuario() {
            return this.usuario;
        }
        public String getContrasena() {
            return this.contrasena;
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
        public void setUsuario(string usuario) {
            this.usuario = usuario;
        }
        public void setContrasena(string contrasena) {
            this.contrasena = contrasena;
        }
    }
}

