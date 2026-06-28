using Negocio;
using System;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class AsignarTurnos : System.Web.UI.Page {
        private readonly NegocioMedico objNegocioMedico = new NegocioMedico();
        private readonly NegocioTurno objNegocioTurno = new NegocioTurno();

        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                cargarMedicos();
            }
        }
        protected void btnAsignarTurno_Click(object sender, EventArgs e) {

        }

        private void cargarMedicos() {
            ddlMedico.Items.Clear();
            ddlMedico.DataSource = new NegocioMedico().getTodos();
            ddlMedico.DataValueField = "legajo";
            ddlMedico.DataTextField = "nombreMedico";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione medico --", "0"));
        }
    }
}