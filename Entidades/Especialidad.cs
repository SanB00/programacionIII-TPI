namespace Entidades {
    public class Especialidad {
        private int id;
        private string nombre;

        public Especialidad(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }
        public Especialidad() { }

        public int getId() { return id; }
        public string getNombre() { return nombre; }
        public void setId(int id) { this.id = id; }
        public void setNombre(string nombre) { this.nombre = nombre; }
    }
}
