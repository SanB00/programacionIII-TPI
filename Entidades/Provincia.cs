namespace Entidades {
    internal class Provincia {
        private int id;
        private string nombre;

        public Provincia(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }
        public Provincia() { }

        public int getId() { return id; }
        public string getNombre() { return nombre; }
        public void setId(int id) { this.id = id; }
        public void setNombre(string nombre) { this.nombre = nombre; }
    }
}
