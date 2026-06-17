<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="abmlPacientes.aspx.cs" Inherits="Vistas.abmlPacientes" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h1>PACIENTES</h1>
    <br />
    <table>
        <tr>
            <td>DNI</td>
            <td><asp:TextBox ID="txtDni" runat="server" MaxLength="8" /></td>
            <td>Nombre</td>
            <td><asp:TextBox ID="txtNombre" runat="server" /></td>
        </tr>
        <tr>
            <td>Apellido</td>
            <td><asp:TextBox ID="txtApellido" runat="server" /></td>
            <td>Sexo</td>
            <td>
                <asp:DropDownList ID="ddlSexo" runat="server">
                    <asp:ListItem Value="">--</asp:ListItem>
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Nacionalidad</td>
            <td><asp:DropDownList ID="ddlNacionalidad" runat="server" /></td>
            <td>Fecha Nac.</td>
            <td><asp:TextBox ID="txtNacimiento" runat="server" TextMode="Date" /></td>
        </tr>
        <tr>
            <td>Dirección</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" /></td>
            <td>Provincia</td>
            <td><asp:DropDownList ID="ddlProvincia" runat="server" /></td>
        </tr>
        <tr>
            <td>Localidad</td>
            <td><asp:DropDownList ID="ddlLocalidad" runat="server" /></td>
            <td>Correo</td>
            <td><asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" /></td>
        </tr>
        <tr>
            <td>Teléfono</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" /></td>
            <td></td>
            <td></td>
        </tr>
    </table>

    <br />
    Buscar por DNI: <asp:TextBox ID="txtFiltro" runat="server" />
    
    <br /><br />
    <asp:GridView ID="grdPacientes" runat="server"
        AutoGenerateColumns="false"
        DataKeyNames="DNI"
        AllowPaging="true" PageSize="8"
        GridLines="Horizontal"
        Width="900px" 
        Font-Names="Arial" Font-Size="Small"
        EmptyDataText="No se encontraron pacientes.">
        <HeaderStyle BackColor="#102a43" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="#f0f4f8" />
        <Columns>
            <asp:BoundField DataField="DNI"          HeaderText="DNI" />
            <asp:BoundField DataField="Nombre"       HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido"     HeaderText="Apellido" />
            <asp:BoundField DataField="Sexo"         HeaderText="Sexo" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
            <asp:BoundField DataField="FechaNac"     HeaderText="F. Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Direccion"    HeaderText="Dirección" />
            <asp:BoundField DataField="Localidad"    HeaderText="Localidad" />
            <asp:BoundField DataField="Provincia"    HeaderText="Provincia" />
            <asp:BoundField DataField="Correo"       HeaderText="Correo" />
            <asp:BoundField DataField="Telefono"     HeaderText="Teléfono" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Edit" Text="Editar" />
                    &nbsp;|&nbsp;
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Eliminar"
                        OnClientClick="return confirm('¿Eliminar paciente?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>
</asp:Content>
