using Entidades;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

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
            ddlProvincia.DataValueField = "idProvincia";
            ddlProvincia.DataTextField = "nombre";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        private void cargarLocalidades(int idProvincia) {
            ddlLocalidad.Items.Clear();

            if (idProvincia > 0) {
                ddlLocalidad.DataSource = objNegocioLocalidad.getPorProvincia(idProvincia);
                ddlLocalidad.DataValueField = "idLocalidad";
                ddlLocalidad.DataTextField = "nombre";
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
            #region 1) obtener datos del formulario
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string sexo = ddlSexo.SelectedValue;
            string nacionalidad = ddlNacionalidad.SelectedValue;
            DateTime nacimiento = DateTime.Parse(txtNacimiento.Text);
            string direccion = txtDireccion.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            #endregion
            #region 2) validar datos del formulario

            string mensajeError = "";
            if (!Common.esUnNroValido(dni)) {
                mensajeError += "\n El DNI debe ser solo numeros. ";
            }
            if (!Common.estaElTextoDentroDelRango(dni, 1, 10)) {
                mensajeError += "\n El dni debe tener entre 1 y 10 caracteres. ";
            }
            if (!Common.estaElTextoDentroDelRango(nombre)) {
                mensajeError += $"\n El nombre debe tener entre {Common.MIN_CHARS_TEXTO} y {Common.MAX_CHARS_TEXTO} caracteres. ";
            }
            if (!Common.estaElTextoDentroDelRango(apellido)) {
                mensajeError += $"\n El apellido debe tener entre {Common.MIN_CHARS_TEXTO} y {Common.MAX_CHARS_TEXTO} caracteres. ";
            }
            if (!DateTime.TryParse(txtNacimiento.Text, out nacimiento)) {
                lblMensaje.Text = "Ingrese una fecha válida.";
                return;
            }
            if (!Common.estaElTextoDentroDelRango(direccion, 3, 100)) {
                mensajeError += "\n La direccion debe tener entre 3 y 100 caracteres. ";
            }
            if (!Common.estaElTextoDentroDelRango(correo, 5, 50)) {
                mensajeError += "\n El correo debe tener entre 5 y 50 caracteres. ";
            }
            if (!(sexo.Equals("M") || sexo.Equals("F"))) {
                mensajeError += "\n Debe seleccionar un sexo M o F. ";
            }

            if (ddlProvincia.SelectedIndex == 0 || ddlLocalidad.SelectedIndex == 0) {
                mensajeError += "\n Debe seleccionar una provincia y una localidad. ";
            }
            if (!Common.esUnNroValido(telefono)) {
                mensajeError += "\n El telefono debe ser solo numeros. ";
            }

            if (!string.IsNullOrEmpty(mensajeError)) {
                lblMensaje.Text = mensajeError;
                Common.mostrarMensajeEnAlerta(mensajeError, this);
                return;
            }
            #endregion
            #region 3) crear entidad y guardar en la base de datos
            Paciente objPaciente = new Paciente();

            objPaciente.setDni(dni);
            objPaciente.setNombre(nombre);
            objPaciente.setApellido(apellido);
            objPaciente.setSexo(sexo);
            objPaciente.setNacionalidad(nacionalidad);
            objPaciente.setFechaNacimiento(nacimiento);
            objPaciente.setDireccion(direccion);
            objPaciente.setCorreoElectronico(correo);
            objPaciente.setTelefono(telefono);
            objPaciente.setIdProvincia(idProvincia);
            objPaciente.setIdLocalidad(idLocalidad);
            objPaciente.setEstado(true);

            bool ok = new NegocioPaciente().agregarPaciente(objPaciente);
            #endregion
            #region 4) limpiar formulario y mostrar mensaje de éxito o error

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
            #endregion
        }

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");
            ddlLocalidad.DataSource = new NegocioLocalidad().getPorProvincia(
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
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != 0) {
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddl_eit_estado");

                NegocioProvincia negocioProv = new NegocioProvincia();
                NegocioLocalidad negocioLoc = new NegocioLocalidad();
                NegocioPaciente negocioPac = new NegocioPaciente();

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

                bool estado = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Estado"));

                if (estado == true) {
                    ddlEstado.SelectedValue = "True";
                } else {
                    ddlEstado.SelectedValue = "False";
                }

            }
        }

        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow fila = gvPacientes.Rows[e.RowIndex];
            Paciente datosNuevos = new Paciente();
            
            datosNuevos.setDni(((Label)gvPacientes.Rows[e.RowIndex].FindControl("lbl_eit_DNI")).Text);
            datosNuevos.setNombre(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_nombrePaciente")).Text);
            datosNuevos.setApellido(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text);
            datosNuevos.setSexo(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Sexo")).SelectedValue);
            datosNuevos.setNacionalidad(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            datosNuevos.setFechaNacimiento(DateTime.Parse(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("text_eit_Nacimiento")).Text));
            datosNuevos.setDireccion(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("text_eit_Direccion")).Text);
            datosNuevos.setCorreoElectronico(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_Correo")).Text);
            datosNuevos.setTelefono(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text);
            datosNuevos.setIdProvincia(Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue));
            datosNuevos.setIdLocalidad(Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue));
            datosNuevos.setEstado(Convert.ToBoolean(((DropDownList)fila.FindControl("ddl_eit_estado")).SelectedValue));
            
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

