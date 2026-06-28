using Datos;

namespace Negocio {
    public class NegocioUsuario {
        public string validarUsuario(string usuario, string contrasenia) {
            DaoUsuario dao = new DaoUsuario();
            return dao.validarUsuario(usuario, contrasenia);
        }
    }
}
