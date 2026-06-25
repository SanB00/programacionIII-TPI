namespace Entidades {
    public class Medico : Persona {
        private string legajo;
        private string especialidad;

        public string getLegajo() {
            return this.legajo;
        }

        public void setLegajo(string legajo) {
            this.legajo = legajo;
        }

        public string getEspecialidad() {
            return this.especialidad;
        }

        public void setEspecialidad(string especialidad) {
            this.especialidad = especialidad;
        }
    }
}
