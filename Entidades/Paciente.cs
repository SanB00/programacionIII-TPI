namespace Entidades {
    public class Paciente : Persona {
        private int idLocalidad;
        private int idProvincia;

        public int getIdLocalidad() {
            return this.idLocalidad;
        }
        public void setIdLocalidad(int idLocalidad) {
            this.idLocalidad = idLocalidad;
        }
        public int getIdProvincia() {
            return this.idProvincia;
        }
        public void setIdProvincia(int idProvincia) {
            this.idProvincia = idProvincia;
        }
    }
}
