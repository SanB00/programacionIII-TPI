using System;

namespace Vistas {
    public partial class login : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {
            //TODO Borrar esta linea de codigo cuando se implemente la logica de login
            txtUsuario.Text = "admin";
            txtContrasenia.Text = "1234";
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e) {
            string usuario = txtUsuario.Text;
            string contraseña = txtContrasenia.Text;

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