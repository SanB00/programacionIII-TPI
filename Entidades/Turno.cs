namespace Entidades {
    public class Turno {
        private int idTurno;
        private int legajo;
        private string dniPaciente;
        private string fecha;
        private bool estado;
        private int horarioInicio;

        public int getIdTurno() { return idTurno; }
        public void setIdTurno(int v) { idTurno = v; }

        public int getLegajo() { return legajo; }
        public void setLegajo(int v) { legajo = v; }

        public string getDniPaciente() { return dniPaciente; }
        public void setDniPaciente(string v) { dniPaciente = v; }

        public string getFecha() { return fecha; }
        public void setFecha(string v) { fecha = v; }
        public bool getEstado() { return estado; }
        public void setEstado(bool v) { estado = v; }
        public int getHorarioInicio() { return horarioInicio; }
        public void setHorarioInicio(int v) { horarioInicio = v; }
    }
}
