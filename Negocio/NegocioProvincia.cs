using Datos;
using System.Data;
namespace Negocio {
    public class NegocioProvincia {
        private readonly DaoProvincia objDaoProvincia = new DaoProvincia();
        public NegocioProvincia() {
        }
        public DataTable getTodos() {
            return objDaoProvincia.getTodos();
        }
    }
}
