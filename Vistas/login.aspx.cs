using Negocio;
using System;

namespace Vistas {
    public partial class login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if (!IsPostBack) {
            //    txtUsuario.Text = "admin";
            //    txtContrasenia.Text = "1234";
            //}
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e) {
            NegocioUsuario negocio = new NegocioUsuario();

            bool valido = negocio.ValidarUsuario(txtUsuario.Text, txtContrasenia.Text);

            if (valido) {
                Session["Usuario"] = txtUsuario.Text;
                Response.Redirect("HomeAdmin.aspx");
            } else {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }

    }
}
    
