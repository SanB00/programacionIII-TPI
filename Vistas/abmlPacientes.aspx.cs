using Negocio;
using System;
using System.Web.UI.WebControls;

namespace Vistas {
    public partial class abmlPacientes : System.Web.UI.Page {
        private readonly NegocioProvincia objNegocioProvincia = new NegocioProvincia();
        private readonly NegocioLocalidad objNegocioLocalidad = new NegocioLocalidad();

        protected void page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                cargarProvincias();
                cargarLocalidades(0);
            }
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
    }
}

/*
use BDClinica
go
INSERT INTO LOCALIDAD (IdLocalidad, Nombre, IdProvincia)
SELECT 1, 'Don Torcuato', 1 UNION
SELECT 2, 'Tigre', 1 UNION
SELECT 3, 'San Fernando', 1 UNION
SELECT 4, 'San Isidro', 1 UNION
SELECT 5, 'Vicente López', 1 UNION
SELECT 6, 'La Plata', 1 UNION
SELECT 7, 'Mar del Plata', 1 UNION
SELECT 8, 'Palermo', 5 UNION
SELECT 9, 'Recoleta', 5 UNION
SELECT 10, 'Belgrano', 5 UNION
SELECT 11, 'Córdoba Capital', 6 UNION
SELECT 12, 'Río Cuarto', 6;
GO