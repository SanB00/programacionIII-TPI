/*
   DNI CHAR(8) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Sexo CHAR(1),
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE,
    Direccion VARCHAR(100),
    CorreoElectronico VARCHAR(100),
    Telefono VARCHAR(20)
*/
using System;

namespace Entidades {
    public class Persona {
        private String dni;
        private String nombre;
        private String apellido;
        private String sexo;
        private String nacionalidad;
        private DateTime fechaNacimiento;
        private String direccion;
        private String correoElectronico;
        private String telefono;
        private int idLocalidad;
        private int idProvincia;
        private bool estado;
        public String getDni() {
            return this.dni;
        }

        public void setDni(String dni) {
            this.dni = dni;
        }

        // Getters
        public String getNombre() {
            return nombre;
        }

        public String getApellido() {
            return apellido;
        }

        public String getSexo() {
            return sexo;
        }

        public String getNacionalidad() {
            return nacionalidad;
        }

        public DateTime getFechaNacimiento() {
            return fechaNacimiento;
        }

        public String getDireccion() {
            return direccion;
        }

        public String getCorreoElectronico() {
            return correoElectronico;
        }

        public String getTelefono() {
            return telefono;
        }
        public int getIdLocalidad() {
            return idLocalidad;
        }
        public int getIdProvincia() {
            return idProvincia;
        }
        public bool getEstado() {
            return estado;
        }

        // Setters
        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public void setApellido(String apellido) {
            this.apellido = apellido;
        }

        public void setSexo(String sexo) {
            this.sexo = sexo;
        }

        public void setNacionalidad(String nacionalidad) {
            this.nacionalidad = nacionalidad;
        }

        public void setFechaNacimiento(DateTime fechaNacimiento) {
            this.fechaNacimiento = fechaNacimiento;
        }

        public void setDireccion(String direccion) {
            this.direccion = direccion;
        }

        public void setCorreoElectronico(String correoElectronico) {
            this.correoElectronico = correoElectronico;
        }

        public void setTelefono(String telefono) {
            this.telefono = telefono;
        }
        public void setIdLocalidad(int idLocalidad) {
            this.idLocalidad = idLocalidad;
        }
        public void setIdProvincia(int idProvincia) {
           this.idProvincia = idProvincia;
        }
        public void setEstado(bool estado) {
            this.estado = estado;
        }
    }
}
