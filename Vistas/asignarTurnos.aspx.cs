using Entidades;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AsignarTurnos : System.Web.UI.Page {
        private readonly NegocioMedico objNegocioMedico = new NegocioMedico();
        private readonly NegocioTurno objNegocioTurno = new NegocioTurno();
        private readonly NegocioPaciente objNegocioPaciente = new NegocioPaciente();

        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                cargarEspecialidades();
                cargarMedicos(0);
            }
        }

        private void cargarEspecialidades() {
            ddlEspecialidad.DataSource = new NegocioEspecialidad().getTodos();
            ddlEspecialidad.DataTextField = "Nombre";
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", "0"));
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e) {
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            cargarMedicos(idEspecialidad);
        }

        private void cargarMedicos(int idEspecialidad) {
            ddlMedico.Items.Clear();
            if (idEspecialidad > 0) {
                ddlMedico.DataSource = objNegocioMedico.getTodosPorEspecialidad(idEspecialidad);
                ddlMedico.DataValueField = "Legajo";
                ddlMedico.DataTextField = "NombreMedico";
                ddlMedico.DataBind();
            }
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione Médico --", "0"));
        }

        protected void btnAsignarTurno_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(ddlEspecialidad.SelectedValue) == 0
                || Convert.ToInt32(ddlMedico.SelectedValue) == 0
                || string.IsNullOrWhiteSpace(txtDiaTurno.Text)
                || string.IsNullOrWhiteSpace(txtDniPaciente.Text)) {
                lblMensaje.Text = "Complete todos los campos.";
                return;
            }
            if (!objNegocioPaciente.existeDNI(txtDniPaciente.Text)) {
                lblMensaje.Text = "Error: El DNI ingresado no corresponde a ningún paciente registrado.";
                return;
            }
            Turno t = new Turno();
            t.setLegajo(Convert.ToInt32(ddlMedico.SelectedValue));
            t.setDniPaciente(txtDniPaciente.Text.Trim());
            t.setFecha(txtDiaTurno.Text);
            t.setHorarioInicio(Convert.ToInt32(ddlHorario.SelectedValue));

            bool ok = objNegocioTurno.agregarTurno(t);

            if (ok) {
                lblMensaje.Text = "Turno asignado correctamente.";
                txtDniPaciente.Text = "";
                txtDiaTurno.Text = "";
                ddlEspecialidad.SelectedIndex = 0;
                ddlMedico.SelectedIndex = 0;
                ddlHorario.SelectedIndex = 0;
            } else {
                lblMensaje.Text = "Error: ese médico ya tiene un turno en ese día y horario, o los datos son inválidos.";
            }
        }
    }
}