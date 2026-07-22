namespace Entidades {
    public class Usuario {

        private int legajo;
        public int idUsuario;
        public string nombreUsuario;
        public string contrasenia;

        public int getLegajo() {
            return legajo;
        }
        public int getIdUsuario() { return idUsuario; }
        public void setUsuario(int v) { idUsuario = v; }

        public string getNombreUsuario() { return nombreUsuario; }
        
        public void setLegajo(int legajo) {
            this.legajo = legajo;
        }
        public void setNombreUsuario(string v) { nombreUsuario = v; }

        public string getContrasenia() { return contrasenia; }
        public void setContrasenia(string v) { contrasenia = v; }
    }
}