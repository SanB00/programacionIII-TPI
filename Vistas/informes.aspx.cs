using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class informes : System.Web.UI.Page {
        private int hola = 0;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
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