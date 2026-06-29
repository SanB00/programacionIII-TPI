<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .contenedorInforme {
            width: 100%;
            max-width: 900px;
        }

        .titulo {
            font-size: x-large;
            font-weight: bold;
        }

        .resultado {
            font-weight: bold;
            color: #102a43;
        }

        .filaControles td {
            padding: 8px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>INFORMES</h1>

<br />
<br />

<asp:Label ID="lblUsuario" runat="server"></asp:Label>

<br />
<br />

<table class="contenedorInforme">

    <tr class="filaControles">
        <td>
            <asp:Label ID="lblInformes" runat="server"
                Text="Seleccione Informe">
            </asp:Label>
        </td>

        <td>
            <asp:DropDownList ID="ddlTipoInforme" runat="server">
                <asp:ListItem Value="Asistencia">
                    Asistencia de pacientes
                </asp:ListItem>

                <asp:ListItem Value="Especialidad">
                    Turnos por especialidad
                </asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>

    <tr class="filaControles">
        <td>
            <asp:Label ID="lblFechaDesde" runat="server"
                Text="Desde">
            </asp:Label>
        </td>

        <td>
            <asp:TextBox ID="txtFechaDesde"
                runat="server"
                TextMode="Date">
            </asp:TextBox>
        </td>

        <td>
            <asp:Label ID="lblFechaHasta" runat="server"
                Text="Hasta">
            </asp:Label>
        </td>

        <td>
            <asp:TextBox ID="txtFechaHasta"
                runat="server"
                TextMode="Date">
            </asp:TextBox>
        </td>
    </tr>

    <tr class="filaControles">
        <td colspan="4">
            <asp:Button ID="btnGenerarInforme"
                runat="server"
                Text="Generar Informe"
                OnClick="btnGenerarInforme_Click" />
        </td>
    </tr>

    <tr>
        <td colspan="4">
            <br />

            <asp:Label ID="lblResultado"
                runat="server"
                CssClass="resultado">
            </asp:Label>

            <br />
            <br />

            <asp:GridView ID="gvInforme"
                runat="server"
                AutoGenerateColumns="true">
            </asp:GridView>
        </td>
    </tr>

</table>
    <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>
</asp:Content>
