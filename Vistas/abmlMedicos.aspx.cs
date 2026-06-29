using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AbmlMedicos : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();
        private readonly NegocioMedico objNegocioMedico = new NegocioMedico();
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                cargarProvincias();
                cargarEspecialidades();
                cargarGrid();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e) {

            string legajo = txtLegajo.Text.Trim();
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nacionalidad = txtNacionalidad.Text.Trim();
            DateTime nacimiento = DateTime.Parse(txtNacimiento.Text.Trim());
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
                || string.IsNullOrWhiteSpace(txtNacimiento.Text)
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

        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e) {
            int idProvinciaSeleccionada = Convert.ToInt32(ddlProvincia.SelectedValue);

            if (idProvinciaSeleccionada > 0) {
                NegocioLocalidad negLocalidad = new NegocioLocalidad();

                ddlLocalidad.DataSource = negLocalidad.getPorProvincia(idProvinciaSeleccionada);
                ddlLocalidad.DataTextField = "Nombre";
                ddlLocalidad.DataValueField = "IdLocalidad";
                ddlLocalidad.DataBind();

                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione Localidad --", "0"));

                ddlLocalidad.Enabled = true;
            } else {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione Provincia Primero --", "0"));
                ddlLocalidad.Enabled = false;
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
        private void cargarEspecialidades() {
            NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();

            ddlEspecialidad.DataSource = negEspecialidad.getTodos();

            ddlEspecialidad.DataTextField = "Nombre"; 
            ddlEspecialidad.DataValueField = "IdEspecialidad";    

            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
        }
        private void cargarProvincias() {
            NegocioProvincia negProvincia = new NegocioProvincia();

            ddlProvincia.DataSource = negProvincia.getTodos();
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataValueField = "IdProvincia"; 
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione Provincia --", "0"));
        }

        private void cargarGrid() {
            NegocioMedico neg = new NegocioMedico();
            grdMedicos.DataSource = neg.obtenerTablaMedicos();
            grdMedicos.DataBind();
        }

        protected void btnFiltrarMedicos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFiltro.Text)) {
                int legajoBuscado = Convert.ToInt32(txtFiltro.Text.Trim());

                NegocioMedico negocio = new NegocioMedico();
                DataTable tablaFiltrada = negocio.filtrarPorLegajo(legajoBuscado);

                grdMedicos.DataSource = tablaFiltrada;
                grdMedicos.DataBind();
            } else {
                cargarGrid();
            }
        }
    }
}