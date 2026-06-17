using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                lblBienvenida.Text = "Bienvenido " + Session["Usuario"];
            }
        }

        protected void lbMedicos_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/abmlMedicos.aspx");
        }

        protected void lbPacientes_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/abmlPacientes.aspx");
        }
        protected void lbInformes_admin_Click(object sender, EventArgs e) {
            Response.Redirect("~/informes.aspx");
        }
    }
}