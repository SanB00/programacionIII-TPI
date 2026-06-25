using Datos;

namespace Negocio {
    public class NegocioUsuario {
        public bool ValidarUsuario(string usuario, string contrasenia) {
            DaoUsuario dao = new DaoUsuario();
            return dao.ValidarUsuario(usuario, contrasenia);
        }
    }
}
