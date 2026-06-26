using System;

namespace Vistas {
    public partial class principal : System.Web.UI.MasterPage {
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                lblUsuario.Text = "Usuario: " + Session["Usuario"];
            }
            if (Session["Usuario"] != null)
                lblUsuario.Text = Session["Usuario"].ToString();
            else
                Response.Redirect("login.aspx");
        }
    }
}