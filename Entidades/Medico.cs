using System;

namespace Entidades {
    public class Medico : Persona {
        private int legajo;
        private int idEspecialidad;
        private int diasAtencion;
        private int horarioAtencion;
        private String usuario;
        private String contrasena;

       public int getLegajo() {
            return this.legajo;
        }
        public int getIdEspecialidad() {
            return this.idEspecialidad;
        }
        public int getDiasAtencion() {
            return this.diasAtencion;
        }
        public int getHorarioAtencion() {
            return this.horarioAtencion;
        }
        public String getUsuario() {
            return this.usuario;
        }
        public String getContrasena() {
            return this.contrasena;
        }

        public void setLegajo(int legajo) {
            this.legajo = legajo;
        }
        public void setIdEspecialidad(int especialidad) {
            this.idEspecialidad = especialidad;
        }
        public void setDiasAtencion(int diasAtencion) {
            this.diasAtencion = diasAtencion;
        }
        public void setHorarioAtencion(int horarioAtencion) { 
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

