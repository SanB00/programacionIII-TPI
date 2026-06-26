using System;

namespace Entidades {
    public class Turno {
        int id;
        int idEspecialidad;
        String legajoMedico;
        String dniPaciente;
        String horario;
        String dia;

        public Turno() { }

        //  Getters

        public int getId() {
            return id;
        }

        public int getIdEspecialidad() {
            return idEspecialidad;
        }

        public String getLegajoMedico() {
            return legajoMedico;
        }

        public String getDniPaciente() {
            return dniPaciente;
        }

        public String getHorario() {
            return horario;
        }

        public String getDia() {
            return dia;
        }

        // --- Setters ---

        public void setId(int id) {
            this.id = id;
        }

        public void setIdEspecialidad(int idEspecialidad) {
            this.idEspecialidad = idEspecialidad;
        }

        public void setLegajoMedico(String legajoMedico) {
            this.legajoMedico = legajoMedico;
        }

        public void setDniPaciente(String dniPaciente) {
            this.dniPaciente = dniPaciente;
        }

        public void setHorario(String horario) {
            this.horario = horario;
        }

        public void setDia(String dia) {
            this.dia = dia;
        }
    }
}
