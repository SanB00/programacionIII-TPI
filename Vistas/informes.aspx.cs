using System;
using Negocio;
using System.Data;

namespace Vistas {
    public partial class Informes : System.Web.UI.Page {
        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                lblUsuario.Text = "Usuario: " + Session["Usuario"];
            }
        }

        protected void btnGenerarInforme_Click(object sender, EventArgs e) {
            if (txtFechaDesde.Text == "" || txtFechaHasta.Text == "") {
                lblResultado.Text = "Debe ingresar ambas fechas.";
                gvInforme.DataSource = null;
                gvInforme.DataBind();
                return;
            }

            DateTime desde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtFechaHasta.Text);

            if (desde > hasta) {
                lblResultado.Text = "La fecha Desde no puede ser mayor que la fecha Hasta.";
                gvInforme.DataSource = null;
                gvInforme.DataBind();
                return;
            }

            NegocioInforme negocio = new NegocioInforme();
            DataTable dt;

            switch (ddlTipoInforme.SelectedValue) {
                case "Asistencia":
                    dt = negocio.obtenerAsistenciaPacientes(desde, hasta);
                    break;

                case "Especialidad":
                    dt = negocio.obtenerTurnosPorEspecialidad(desde, hasta);
                    break;

                default:
                    lblResultado.Text = "Debe seleccionar un tipo de informe.";
                    gvInforme.DataSource = null;
                    gvInforme.DataBind();
                    return;
            }

            gvInforme.DataSource = dt;
            gvInforme.DataBind();

            lblResultado.Text = "Se encontraron " + dt.Rows.Count + " registros.";
        }
    }
}