using System;

namespace Vistas {
    public partial class HomeAdmin : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                lblBienvenida.Text = "Bienvenido " + Session["Usuario"];
            }
        }

        protected void lbMedicos_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/abmlMedicos.aspx");
        }

        protected void lbTurnos_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/asignarTurnos.aspx");
        }

        protected void lbPacientes_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/AbmlPacientes.aspx");
        }
        protected void lbInformes_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/informes.aspx");
        }
    }
}