<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="HomeMedico.aspx.cs" Inherits="Vistas.TurnosMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mis Turnos</h1>
    <br />

    <asp:GridView ID="gvTurnos" runat="server"
        AutoGenerateColumns="False"
        AllowPaging="True" PageSize="8"
        OnPageIndexChanging="gvTurnos_PageIndexChanging"
        GridLines="Horizontal"
        Width="744px"
        Font-Names="Arial" Font-Size="Small"
        EmptyDataText="No tiene turnos asignados.">
        <HeaderStyle BackColor="#102a43" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="#f0f4f8" />
        <Columns>
            <asp:BoundField DataField="Paciente"    HeaderText="Paciente" />
            <asp:BoundField DataField="Fecha"       HeaderText="Fecha" />
            <asp:BoundField DataField="Horario"     HeaderText="Horario" />
            <asp:BoundField DataField="Asistencia"  HeaderText="Asistencia" />
            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
        </Columns>
    </asp:GridView>
</asp:Content>
