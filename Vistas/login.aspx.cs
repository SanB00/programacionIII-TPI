using Negocio;
using System;

namespace Vistas {
    public partial class login : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {
            
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e) {
            NegocioUsuario negocio = new NegocioUsuario();

            string tipoUsuario = negocio.validarUsuario(txtUsuario.Text, txtContrasenia.Text);

            if (tipoUsuario!=null) {
                Session["Usuario"] = txtUsuario.Text;
                Session["TipoUsuario"] = tipoUsuario;

                if (tipoUsuario == "Administrador") {
                    Response.Redirect("HomeAdmin.aspx");
                } 
                else if (tipoUsuario == "Medico") {
                    Response.Redirect("turnosMedico.aspx");
                } 
            } else {
                txtUsuario.Text = "";
                lblMensaje.Visible = true;
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }

    }
}
    
