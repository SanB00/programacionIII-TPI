using System;

namespace Vistas {
    public partial class login : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e) {
            string usuario = tbUsuario.Text;
            string contraseña = tbContrasenia.Text;

            if (usuario == "admin" && contraseña == "1234") {
                Session["Usuario"] = usuario;

                Response.Redirect("HomeAdmin.aspx");
            } else {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                lblMensaje.Visible = true;
            }
        }
    }
}