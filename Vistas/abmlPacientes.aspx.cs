using Entidades;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AbmlPacientes : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();
        private readonly NegocioPaciente objNegocioPaciente = new NegocioPaciente();

        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
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

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");

            NegocioLocalidad negocio = new NegocioLocalidad();

            ddlLocalidad.DataSource = negocio.getPorProvincia(
                Convert.ToInt32(ddlProvincia.SelectedValue)
            );
            ddlLocalidad.DataTextField = "Nombre";
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e) {
            gvPacientes.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            gvPacientes.EditIndex = -1;
            cargarGridView();
        }
        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) != 0) {
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");

                NegocioProvincia negocioProv = new NegocioProvincia();
                NegocioLocalidad negocioLoc = new NegocioLocalidad();

                ddlProvincia.DataSource = negocioProv.getTodos();
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();

                string idProvincia = DataBinder.Eval(e.Row.DataItem, "IdProvincia").ToString();

                if (ddlProvincia.Items.FindByValue(idProvincia) != null) {
                    ddlProvincia.SelectedValue = idProvincia;
                }

                int provId = Convert.ToInt32(idProvincia);

                ddlLocalidad.DataSource = negocioLoc.getPorProvincia(provId);
                ddlLocalidad.DataTextField = "Nombre";
                ddlLocalidad.DataValueField = "IdLocalidad";
                ddlLocalidad.DataBind();

                string idLocalidad = DataBinder.Eval(e.Row.DataItem, "IdLocalidad").ToString();

                if (ddlLocalidad.Items.FindByValue(idLocalidad) != null) {
                    ddlLocalidad.SelectedValue = idLocalidad;
                }
            }
        }

        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            Paciente datosNuevos = new Paciente();
            DropDownList ddlProvincia = (DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Provincia");
            DropDownList ddlLocalidad = (DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Localidad");

            datosNuevos.setDni(((Label)gvPacientes.Rows[e.RowIndex].FindControl("lbl_eit_DNI")).Text);
            datosNuevos.setNombre(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_nombrePaciente")).Text);
            datosNuevos.setApellido(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text);
            datosNuevos.setSexo(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Sexo")).SelectedValue);
            datosNuevos.setNacionalidad(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            datosNuevos.setFechaNacimiento(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("text_eit_Nacimiento")).Text);
            datosNuevos.setDireccion(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("text_eit_Direccion")).Text);
            datosNuevos.setCorreoElectronico(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_Correo")).Text);
            datosNuevos.setTelefono(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text);
            datosNuevos.setIdProvincia(Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue));
            datosNuevos.setIdLocalidad(Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue));
            datosNuevos.setEstado(Convert.ToBoolean((((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_estado")).SelectedValue)));

            NegocioPaciente negocio = new NegocioPaciente();

            if (negocio.actualizarPaciente(datosNuevos)) {
                lblMensaje.Text = "Paciente actualizado correctamente.";
                gvPacientes.EditIndex = -1;
                cargarGridView();
            } else {
                lblMensaje.Text = "No se pudo actualizar el paciente.";
            }
        }

    }
}

