<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Vistas.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblBienvenida" runat="server" Text="Bienvenido administrador" Font-Size="Larger" ForeColor="Black" ></asp:Label>
    <p>
    <table class="auto-style1"style="width: 100%; max-width: 600px; border-collapse: separate; border-spacing: 15px; font-family: Arial, sans-serif;">
            <tr>
                <td class="auto-style2" style="border: 1px solid #d9e2ec; padding: 30px; text-align: center; width: 50%;">
                    <asp:LinkButton ID="lbMedicos_admin" runat="server" Font-Bold="True" ForeColor="#102a43" Font-Size="Medium" style="text-decoration: none;" OnClick="lbMedicos_admin_Click">Ir a Médicos</asp:LinkButton>
                </td>
                <td class="auto-style2" style="border: 1px solid #d9e2ec; padding: 30px; text-align: center; width: 50%;">
                    <asp:LinkButton ID="lbTurnos_admin" runat="server" Font-Bold="True" ForeColor="#102a43" Font-Size="Medium" style="text-decoration: none;" OnClick="lbTurnos_admin_Click">Ir a Turnos</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="border: 1px solid #d9e2ec; padding: 30px; text-align: center; width: 50%;">
                    <asp:LinkButton ID="lbPacientes_admin" runat="server" Font-Bold="True" ForeColor="#102a43" Font-Size="Medium" style="text-decoration: none;" OnClick="lbPacientes_admin_Click">Ir a Pacientes</asp:LinkButton>
                </td>
                <td class="auto-style2" style="border: 1px solid #d9e2ec; padding: 30px; text-align: center; width: 50%;">
                    <asp:LinkButton ID="lbInformes_admin" runat="server" Font-Bold="True" ForeColor="#102a43" Font-Size="Medium" style="text-decoration: none;" OnClick="lbInformes_admin_Click"> Ir a Informes </asp:LinkButton>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
