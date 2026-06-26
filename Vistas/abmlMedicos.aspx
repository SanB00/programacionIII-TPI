<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="abmlMedicos.aspx.cs" Inherits="Vistas.abmlMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <h1>Médicos</h1>
    <br />
    <table>
        <tr>
            <td>Legajo</td>
            <td><asp:TextBox ID="txtLegajo" runat="server" /></td>
            <td>DNI </td>
            <td><asp:TextBox ID="txtDni" runat="server" MaxLength="8" /></td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td><asp:TextBox ID="txtNombre" runat="server" /></td>
            <td>Apellido</td>
            <td><asp:TextBox ID="txtApellido" runat="server" /></td>
        </tr>
        <tr>
            <td>Sexo</td>
            <td>
                <asp:DropDownList ID="ddlSexo" runat="server">
                    <asp:ListItem Value="">--</asp:ListItem>
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>Fecha Nacimiento</td>
            <td><asp:TextBox ID="txtNacimiento" runat="server" TextMode="Date" /></td>
        </tr>
        <tr>
            <td>Especialidad</td>
            <td><asp:DropDownList ID="ddlEspecialidad" runat="server" /></td>
            <td>Localidad</td>
            <td><asp:DropDownList ID="DropDownList1" runat="server" /></td>
        </tr>
        <tr>
            <td>Provincia</td>
            <td>
                <asp:DropDownList ID="ddlProvincia" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Teléfono</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" /></td>
            <td>Correo</td>
            <td><asp:TextBox ID="txtCorreo" runat="server" /></td>
        </tr>
        <tr>
            <td>Nacionalidad</td>
            <td>
                <asp:TextBox ID="txtNacionalidad" runat="server"></asp:TextBox>
            </td>
            <td>Dirección</td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Dias de Atención</td>
            <td>
                <asp:TextBox ID="txtDiasAtencion" runat="server"></asp:TextBox>
            </td>
            <td>Horarios</td>
            <td>
                <asp:TextBox ID="txtHorarios" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
      
                <asp:Button ID="btnGuardarMedico" runat="server" Text="Guardar" />
      
            </td>
        </tr>
    </table>

    Buscar por Legajo: <asp:TextBox ID="txtFiltro" runat="server" />
    

    <br /><br />
    <asp:GridView ID="grdMedicos" runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="Legajo"
    AllowPaging="true" PageSize="8"
    GridLines="Horizontal"
    Width="600px"
    Font-Names="Arial" Font-Size="Small"
    EmptyDataText="No se encontraron médicos.">
    <HeaderStyle BackColor="#102a43" ForeColor="White" Font-Bold="true" />
    <AlternatingRowStyle BackColor="#f0f4f8" />
    <Columns>
        <asp:BoundField DataField="Legajo"             HeaderText="Legajo"       />
        <asp:BoundField DataField="DNI"                HeaderText="DNI"          />
        <asp:BoundField DataField="Nombre"             HeaderText="Nombre"       />
        <asp:BoundField DataField="Apellido"           HeaderText="Apellido"     />
        <asp:BoundField DataField="NombreEspecialidad" HeaderText="Especialidad" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Edit"   Text="Editar" />
                &nbsp;|&nbsp;
                <asp:LinkButton runat="server" CommandName="Delete" Text="Eliminar"
                    OnClientClick="return confirm('¿Eliminar?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
   

    <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>

</asp:Content>
