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
    }
}

