<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="asignarTurnos.aspx.cs" Inherits="Vistas.asignarTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Asignación de Turnos</h1>
    <table class="auto-style1" style="width: 100%; max-width: 750px; margin: 20px auto;border: 1px solid #e2e8f0; border-radius: 8px; border-collapse: separate; border-spacing: 15px;">
        <tr>
            <td class="auto-style2">Especialidad:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlEspecialidad" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">Dia:</td>
            <td>
                <asp:TextBox ID="txtDiaTurno" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Medico:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlMedico" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">Horario:</td>
            <td>
                <asp:DropDownList ID="ddlHorario" runat="server">
                    <asp:ListItem Value="8">08:00 - 09:00</asp:ListItem>
                    <asp:ListItem Value="9">09:00 - 10:00</asp:ListItem>
                    <asp:ListItem Value="10">10:00 - 11:00</asp:ListItem>
                    <asp:ListItem Value="11">11:00 - 12:00</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Dni Paciente</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtDniPaciente" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Button ID="btnAsignarTurno" runat="server" Text="Asignar turno" OnClick="btnAsignarTurno_Click" />
            </td>
            <td class="auto-style10">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
        </tr>
    </table>
    <br />
    <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>
</asp:Content>
