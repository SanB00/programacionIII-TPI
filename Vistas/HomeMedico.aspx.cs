using Negocio;
using System;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class TurnosMedico : System.Web.UI.Page {
        private int legajoActual;

        protected void page_Load(object sender, EventArgs e) {
            string usuario = Session["Usuario"] as string;
            legajoActual = new NegocioMedico().getLegajoPorUsuario(usuario);

            if (!this.IsPostBack) {
                cargarTurnos();
            }
        }

        private void cargarTurnos() {
            gvTurnos.DataSource = new NegocioTurno().getTurnosPorMedico(legajoActual);
            gvTurnos.DataBind();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvTurnos.PageIndex = e.NewPageIndex;
            cargarTurnos();
        }
    }
}