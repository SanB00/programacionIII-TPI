using Datos;
using Entidades;
using System.Data;

namespace Negocio {
    public class NegocioUsuario {
        DaoUsuario dao = new DaoUsuario();
        public string validarUsuario(string usuario, string contrasenia) {
            return dao.validarUsuario(usuario, contrasenia);
        }

        public DataTable buscarPorLegajo(int legajo) {
            return dao.buscarPorLegajo(legajo);
        }

        public bool actualizarUsuario(Usuario objUsuario) {
            return dao.actualizarUsuario(objUsuario);
        }
    }
}
