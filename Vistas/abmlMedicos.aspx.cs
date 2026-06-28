using Entidades;
using Negocio;
using System;

namespace Vistas {
    public partial class AbmlMedicos : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();
        private readonly NegocioMedico objNegocioMedico = new NegocioMedico();
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {

            string legajo = txtLegajo.Text.Trim();
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nacionalidad = txtNacionalidad.Text.Trim();
            string nacimiento = txtNacimiento.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string dias = txtDiasAtencion.Text.Trim();
            string horario = txtHorario.Text.Trim();

            if (string.IsNullOrWhiteSpace(legajo)
                || string.IsNullOrWhiteSpace(dni)
                || string.IsNullOrWhiteSpace(nombre)
                || string.IsNullOrWhiteSpace(apellido)
                || string.IsNullOrWhiteSpace(nacionalidad)
                || string.IsNullOrWhiteSpace(nacimiento)
                || string.IsNullOrWhiteSpace(direccion)
                || string.IsNullOrWhiteSpace(correo)
                || string.IsNullOrWhiteSpace(telefono)
                || string.IsNullOrWhiteSpace(dias)
                || string.IsNullOrWhiteSpace(horario)
                ) {

                lblMensaje.Text = "Error: No puede dejar campos vacíos o con solo espacios.";

                return;
            }
            if (!long.TryParse(legajo, out long l)) {

                lblMensaje.Text = "El legajo debe ser numérico.";
                return;
            }

            Medico objMedico = new Medico();
            objMedico.setDni(dni);
            objMedico.setLegajo(legajo);
            objMedico.setNombre(nombre);
            objMedico.setApellido(apellido);
            objMedico.setNacionalidad(nacionalidad);
            objMedico.setFechaNacimiento(nacimiento);
            objMedico.setDireccion(direccion);
            objMedico.setCorreoElectronico(correo);
            objMedico.setTelefono(telefono);
            objMedico.setDiasAtencion(dias);
            objMedico.setHorarioAtencion(horario);

            objMedico.setSexo(ddlSexo.SelectedValue);
            objMedico.setIdLocalidad(int.Parse(ddlLocalidad.SelectedValue));
            objMedico.setIdProvincia(int.Parse(ddlProvincia.SelectedValue));
            objMedico.setIdEspecialidad(int.Parse(ddlEspecialidad.SelectedValue));

            bool exito = new NegocioMedico().registrarMedico(objMedico);

            if (exito) {

                lblMensaje.Text = "Se agrego correctamente en la base de datos";
                limpiarCampos();
            } else {
                lblMensaje.Text = "Error al guardar. Verifique que el DNI o Legajo no estén repetidos.";

            }

        }

        private void limpiarCampos() {
            txtLegajo.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacimiento.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDiasAtencion.Text = "";
            txtHorario.Text = "";
            txtNacionalidad.Text = "";

            ddlSexo.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
        }
    }
}