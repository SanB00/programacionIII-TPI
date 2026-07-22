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
        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Guardar") {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow fila = gvTurnos.Rows[index];

                int idTurno = Convert.ToInt32(gvTurnos.DataKeys[index].Value);

                CheckBox chk = (CheckBox)fila.FindControl("chkAsistencia");
                TextBox txt = (TextBox)fila.FindControl("txtObservacion");

                bool asistencia = chk.Checked;
                string observacion = txt.Text;

                bool ok = new NegocioTurno().actualizarTurno(idTurno, asistencia, observacion);

                if (ok) {
                    cargarTurnos();
                }
            }
        }
    }
}