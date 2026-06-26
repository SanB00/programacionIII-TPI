using System;

namespace Vistas {
    public partial class informes : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                lblUsuario.Text = "Usuario: " + Session["Usuario"];
            }
        }

        protected void btnGenerarInforme_Click(object sender, EventArgs e) {
            if (ddlTipoInforme.SelectedValue == "Asistencia") {
                lblResultado.Text = "Reporte de asistencia generado.";
            } else if (ddlTipoInforme.SelectedValue == "Especialidad") {
                lblResultado.Text = "Reporte de especialidades generado.";
            }
        }
    }
}