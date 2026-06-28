using Entidades;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AbmlPacientes : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();
        private readonly NegocioPaciente objNegocioPaciente = new NegocioPaciente();

        protected void page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {
                cargarProvincias();
                cargarLocalidades(0);
                cargarGridView();
            }
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvPacientes.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        private void cargarGridView() {
            gvPacientes.DataSource = objNegocioPaciente.getTodosPacientes();
            gvPacientes.DataBind();
        }
        private void cargarProvincias() {
            ddlProvincia.Items.Clear();

            ddlProvincia.DataSource = objNegocioProvincia.getTodos();
            ddlProvincia.DataValueField = "IdProvincia";
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        private void cargarLocalidades(int idProvincia) {
            ddlLocalidad.Items.Clear();

            if (idProvincia > 0) {
                ddlLocalidad.DataSource = objNegocioLocalidad.getPorProvincia(idProvincia);
                ddlLocalidad.DataValueField = "IdLocalidad";
                ddlLocalidad.DataTextField = "Nombre";
                ddlLocalidad.DataBind();
            }

            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e) {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            cargarLocalidades(idProvincia);
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e) {
            bloqueAgregarPaciente.Visible = true;       
        }

        protected void btnAgregar_Click(object sender, EventArgs e) {
            NegocioPaciente negocio = new NegocioPaciente();
            Paciente nuevo = new Paciente();

            nuevo.setDni(txtDni.Text);
            nuevo.setNombre(txtNombre.Text);
            nuevo.setApellido(txtApellido.Text);
            nuevo.setSexo(ddlSexo.SelectedValue);
            nuevo.setNacionalidad(ddlNacionalidad.SelectedValue);
            nuevo.setFechaNacimiento(txtNacimiento.Text);
            nuevo.setDireccion(txtDireccion.Text);
            nuevo.setCorreoElectronico(txtCorreo.Text);
            nuevo.setTelefono(txtTelefono.Text);
            nuevo.setIdProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            nuevo.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));

            bool ok = negocio.agregarPaciente(nuevo);

            if (ok) {
                lblMensaje.Text = "Paciente agregado correctamente";
                txtDni.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                ddlSexo.SelectedIndex = 0;
                txtNacimiento.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
                txtTelefono.Text = "";
                ddlProvincia.SelectedIndex = 0;
                ddlLocalidad.SelectedIndex = 0;
                bloqueAgregarPaciente.Visible = false;
            } else {
                lblMensaje.Text = "Error al agregar paciente";
            }

        }
    }
    
}

