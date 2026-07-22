<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="HomeMedico.aspx.cs" Inherits="Vistas.TurnosMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mis Turnos</h1>
    <br />

    <asp:GridView ID="gvTurnos" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="IdTurno"
    AllowPaging="True"
    PageSize="8"
    OnPageIndexChanging="gvTurnos_PageIndexChanging"
    OnRowCommand="gvTurnos_RowCommand"
    GridLines="Horizontal"
    Width="744px"
    Font-Names="Arial"
    Font-Size="Small"
    EmptyDataText="No tiene turnos asignados." OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">

    <HeaderStyle BackColor="#102a43" ForeColor="White" Font-Bold="true" />
    <AlternatingRowStyle BackColor="#f0f4f8" />

    <Columns>

        <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
        <asp:BoundField DataField="Horario" HeaderText="Horario" />

        <asp:TemplateField HeaderText="Asistencia">
            <ItemTemplate>
                <asp:CheckBox ID="chkAsistencia"
                    runat="server"
                    Checked='<%# Eval("Asistencia").ToString() == "Presente" %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Observación">
            <ItemTemplate>
                <asp:TextBox ID="txtObservacion"
                    runat="server"
                    Width="180px"
                    Text='<%# Eval("Observacion") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnGuardar"
                    runat="server"
                    Text="Guardar"
                    CommandName="Guardar"
                    CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
</asp:Content>
