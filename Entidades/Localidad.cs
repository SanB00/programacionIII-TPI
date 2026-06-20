namespace Entidades {
    internal class Localidad {
        private int id;
        private int idProvincia;
        private string nombre;

        public Localidad(int id, int idProvincia, string nombre) {
            this.id = id;
            this.idProvincia = idProvincia;
            this.nombre = nombre;
        }
        public Localidad() { }

        public int getId() { return id; }
        public int getIdProvincia() { return idProvincia; }
        public string getNombre() { return nombre; }
        public void setId(int id) { this.id = id; }
        public void setIdProvincia(int idProvincia) { this.idProvincia = idProvincia; }
        public void setNombre(string nombre) { this.nombre = nombre; }
    }
}
