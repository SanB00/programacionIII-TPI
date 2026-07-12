using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AbmlMedicos : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();
        private readonly NegocioMedico objNegocioMedico = new NegocioMedico();
        private readonly NegocioEspecialidad objNegocioEspecialidad = new NegocioEspecialidad();
        private readonly NegocioUsuario objNegocioUsuario = new NegocioUsuario();

        protected void page_Load(object sender, EventArgs e) {

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack) {
                cargarProvincias();
                cargarLocalidades(0);
                cargarEspecialidades();
                cargarGridView();
            }
        }

        private void cargarGridView() {
            gvMedicos.DataSource = objNegocioMedico.obtenerTablaMedicos();
            gvMedicos.DataBind();
        }
        private void cargarProvincias() {

            ddlProvincia.DataSource = objNegocioProvincia.getTodos();
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataValueField = "IdProvincia";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione Provincia --", "0"));
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

        private void cargarEspecialidades() {

            ddlEspecialidad.DataSource = objNegocioEspecialidad.getTodos();

            ddlEspecialidad.DataTextField = "Nombre";
            ddlEspecialidad.DataValueField = "IdEspecialidad";

            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
        }

        private void limpiarCampos() {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacimiento.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtContrasena2.Text = "";

            ddlNacionalidad.SelectedIndex = 0;
            ddl_agregarDiasMedico.SelectedIndex = 0;
            ddl_agregarHorarioMedico.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e) {
            bloqueAgregarMedico.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            bloqueAgregarMedico.Visible = false;
            limpiarCampos();
        }

        protected void btnGuardarMedico_Click(object sender, EventArgs e) {

            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nacionalidad = ddlNacionalidad.SelectedValue;
            string direccion = txtDireccion.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string provincia = ddlProvincia.SelectedValue;
            string localidad = ddlLocalidad.SelectedValue;
            string especialidad = ddlEspecialidad.SelectedValue;
            string dias = ddl_agregarDiasMedico.SelectedValue;
            string horario = ddl_agregarHorarioMedico.SelectedValue;
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            //validaciones
            if (objNegocioMedico.existeDNI(dni)) {
                lbl_mensaje.Text = "El DNI ya se encuentra registrado.";
                return;
            }

            if (objNegocioMedico.existeUsuario(usuario)) {
                lbl_mensaje.Text = "El nombre de usuario ya existe.";
                return;
            }

            if (string.IsNullOrWhiteSpace(dni) || dni.Length != 8 ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(nacionalidad) ||
                string.IsNullOrWhiteSpace(txtNacimiento.Text) ||
                string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contrasena) ||
                string.IsNullOrWhiteSpace(provincia) ||
                string.IsNullOrWhiteSpace(localidad) ||
                string.IsNullOrWhiteSpace(especialidad) ||
                string.IsNullOrWhiteSpace(dias) ||
                string.IsNullOrWhiteSpace(horario)) {

                lbl_mensaje.Text = "Error: Debe completar todos los campos.";
                return;
            }

            int idProvincia = Convert.ToInt32(provincia);
            int idLocalidad = Convert.ToInt32(localidad);
            int idEspecialidad = Convert.ToInt32(especialidad);
            int diasAtencion = Convert.ToInt32(dias);
            int horarioAtencion = Convert.ToInt32(horario);

            if (!DateTime.TryParse(txtNacimiento.Text.Trim(), out DateTime nacimiento)) {
                lbl_mensaje.Text = "La fecha de nacimiento no es válida.";
                return;
            }

            /*
            Validacion de edad, que sea mayor a 21(creo que es la edad minima como para ser medico)
            primero declaro edad que es la fecha de hoy meno el anio de nacimiento

            despues el primer if toma la fecha de nacimiento sin la hora (los datetime tambien guardan hora)
            y si es mayor a la resta ente el dia hoy y la edad ("DateTime.Today.AddYears(-edad)") le resta 1
            porque todavia no cumplio los anios
            dejo la aclaracion porqque es medio engorroso
            */

            int edad = DateTime.Today.Year - nacimiento.Year;

            if (nacimiento.Date > DateTime.Today.AddYears(-edad)) {
                edad--;
            }

            if (edad < 21) {
                lbl_mensaje.Text = "El médico debe ser mayor de edad.";
                return;
            }

            /// carga

            Medico objMedico = new Medico();

            objMedico.setDni(dni);
            objMedico.setNombre(nombre);
            objMedico.setApellido(apellido);
            objMedico.setNacionalidad(nacionalidad);
            objMedico.setFechaNacimiento(nacimiento);
            objMedico.setDireccion(direccion);
            objMedico.setCorreoElectronico(correo);
            objMedico.setTelefono(telefono);
            objMedico.setDiasAtencion(diasAtencion);
            objMedico.setHorarioAtencion(horarioAtencion);
            objMedico.setUsuario(usuario);
            objMedico.setContrasena(contrasena);

            objMedico.setSexo(ddlSexo.SelectedValue);
            objMedico.setIdLocalidad(idLocalidad);
            objMedico.setIdProvincia(idProvincia);
            objMedico.setIdEspecialidad(idEspecialidad);

            bool exito = new NegocioMedico().agregarMedico(objMedico);

            if (exito) {
                lbl_mensaje.Text = "Se agrego correctamente en la base de datos";
                limpiarCampos();
                cargarGridView();
                bloqueAgregarMedico.Visible = false;
            } else {
                lbl_mensaje.Text = "Error al guardar. Verifique que el DNI no esté repetido.";

            }
        }

        protected void btnFiltrarMedicos_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtFiltro.Text)) {
                int legajoBuscado = Convert.ToInt32(txtFiltro.Text.Trim());

                NegocioMedico negocio = new NegocioMedico();
                DataTable tablaFiltrada = negocio.filtrarPorLegajo(legajoBuscado);

                gvMedicos.DataSource = tablaFiltrada;
                gvMedicos.DataBind();
            } else {
                cargarGridView();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e) {
            txtFiltro.Text = "";
            cargarGridView();
        }

        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e) {
            int idProvinciaSeleccionada = Convert.ToInt32(ddlProvincia.SelectedValue);

            if (idProvinciaSeleccionada > 0) {

                ddlLocalidad.DataSource = objNegocioLocalidad.getPorProvincia(idProvinciaSeleccionada);
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

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvMedicos.PageIndex = e.NewPageIndex;
            cargarGridView();
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

        protected void gvMedicos_RowEditing(object sender, GridViewEditEventArgs e) {
            gvMedicos.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            gvMedicos.EditIndex = -1;
            cargarGridView();
        }
        protected void gvMedicos_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != 0) {
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddl_eit_Provincia");
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddl_eit_Localidad");
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddl_eit_estado");
                DropDownList ddlEspecialidad = (DropDownList)e.Row.FindControl("ddl_eit_Especialidad");
                DropDownList ddlDiasAtencion = (DropDownList)e.Row.FindControl("ddl_eit_diasAtencion");
                DropDownList ddlHorarioAtencion = (DropDownList)e.Row.FindControl("ddl_eit_horarioAtencion");

                ddlProvincia.DataSource = objNegocioProvincia.getTodos();
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();

                string idProvincia = DataBinder.Eval(e.Row.DataItem, "IdProvincia").ToString();

                if (ddlProvincia.Items.FindByValue(idProvincia) != null) {
                    ddlProvincia.SelectedValue = idProvincia;
                }

                int provId = Convert.ToInt32(idProvincia);

                ddlLocalidad.DataSource = objNegocioLocalidad.getPorProvincia(provId);
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

                ddlEspecialidad.DataSource = objNegocioEspecialidad.getTodos();
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataBind();

                string idEspecialidad = DataBinder.Eval(e.Row.DataItem, "IdEspecialidad").ToString();

                ddlEspecialidad.SelectedValue = idEspecialidad;

                string horarioAtencion = DataBinder.Eval(e.Row.DataItem, "HorarioAtencion").ToString();

                ddlHorarioAtencion.SelectedValue = horarioAtencion;

                string diaAtencion = DataBinder.Eval(e.Row.DataItem, "DiasAtencion").ToString();

                ddlDiasAtencion.SelectedValue = diaAtencion;
            }
        }

        protected void gvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            GridViewRow fila = gvMedicos.Rows[e.RowIndex];
            Medico datosNuevos = new Medico();
            DropDownList ddlEspecialidad = (DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Especialidad");

            Label lblLegajo = (Label)gvMedicos.Rows[e.RowIndex].FindControl("lbl_eit_legajo");

            datosNuevos.setLegajo(Convert.ToInt32(lblLegajo.Text));
            datosNuevos.setDni(((Label)gvMedicos.Rows[e.RowIndex].FindControl("lbl_eit_DNI")).Text);
            datosNuevos.setNombre(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_nombreMedico")).Text);
            datosNuevos.setApellido(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text);
            datosNuevos.setSexo(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Sexo")).SelectedValue);
            datosNuevos.setNacionalidad(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            datosNuevos.setFechaNacimiento(DateTime.Parse(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("text_eit_Nacimiento")).Text));
            datosNuevos.setDireccion(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("text_eit_Direccion")).Text);
            datosNuevos.setIdLocalidad(Convert.ToInt32(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Localidad")).SelectedValue));
            datosNuevos.setIdProvincia(Convert.ToInt32(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_Provincia")).SelectedValue));
            datosNuevos.setCorreoElectronico(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Correo")).Text);
            datosNuevos.setTelefono(((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text);
            datosNuevos.setIdEspecialidad(Convert.ToInt32(ddlEspecialidad.SelectedValue));
            datosNuevos.setDiasAtencion(Convert.ToInt32(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_diasAtencion")).SelectedValue));
            datosNuevos.setHorarioAtencion(Convert.ToInt32(((DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddl_eit_horarioAtencion")).SelectedValue));
            datosNuevos.setEstado(Convert.ToBoolean(((DropDownList)fila.FindControl("ddl_eit_estado")).SelectedValue));

            if (objNegocioMedico.actualizarMedico(datosNuevos)) {
                lbl_mensaje.Text = "Medico actualizado correctamente.";
                gvMedicos.EditIndex = -1;
                cargarGridView();
            } else {
                lbl_mensaje.Text = "No se pudo actualizar el medico.";
            }
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e) {
            bloqueModificarUsuario.Visible = true;
        }
        protected void btnBuscar_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txt_legajo_modificar.Text)) {
                lbl_mensaje.Text = "Ingrese un legajo para buscar.";
                return;
            }

            gvEditarUsuario.DataSource = objNegocioUsuario.buscarPorLegajo(Convert.ToInt32(txt_legajo_modificar.Text));
            gvEditarUsuario.DataBind();

            btnGuardarUsuario.Visible = true;
            
        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e) {
            bloqueModificarUsuario.Visible = false;
            btnGuardarUsuario.Visible = false;

            gvEditarUsuario.DataSource = null;
            gvEditarUsuario.DataBind();

            txt_legajo_modificar.Text = "";
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e) {

            if (gvEditarUsuario.Rows.Count == 0) {
                lbl_mensaje.Text = "No hay usuario para modificar.";
                return;
            }

            Usuario datosNuevos = new Usuario();
            GridViewRow fila = gvEditarUsuario.Rows[0];

            datosNuevos.setLegajo(Convert.ToInt32(((Label)fila.FindControl("lbl_legajoUsuario")).Text));
            datosNuevos.setNombreUsuario(((TextBox)fila.FindControl("txt_it_Usuario")).Text);
            datosNuevos.setContrasenia(((TextBox)fila.FindControl("txt_contrasena")).Text);

            if (objNegocioUsuario.actualizarUsuario(datosNuevos)) {

                lbl_mensaje.Text = "Usuario actualizado correctamente.";

                bloqueModificarUsuario.Visible = false;
                btnGuardarUsuario.Visible = false;

                txt_legajo_modificar.Text = "";

                gvEditarUsuario.DataSource = null;
                gvEditarUsuario.DataBind();
            } else {
                lbl_mensaje.Text = "No se pudo actualizar el usuario.";
            }
        }

    }
}

