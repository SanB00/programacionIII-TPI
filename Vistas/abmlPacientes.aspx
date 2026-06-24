<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AbmlPacientes.aspx.cs" Inherits="Vistas.AbmlPacientes" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h1>PACIENTES</h1>
    <asp:Button ID="btnAgregarPaciente" runat="server" OnClick="btnAgregarPaciente_Click" Text="Agregar Nuevo Paciente" />
    <br />
    <br />
    <table id="bloqueAgregarPaciente" runat="server" visible="false" border="0">
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
            <td><asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" /></td>
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
            <td style="text-align: right">&nbsp;<asp:Button ID="btnAgregar" runat="server" style="text-align: right" Text="Agregar" />
            </td>
        </tr>
    </table>

    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Buscar por DNI: <asp:TextBox ID="txtFiltro" runat="server" />
    
    <br /><br />
    <asp:GridView ID="gvPacientes" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="DNI"
        AllowPaging="True" PageSize="8"
        GridLines="None"
        Width="900px" 
        Font-Names="Arial" Font-Size="Small"
        EmptyDataText="No se encontraron pacientes." CellPadding="4" ForeColor="#333333" style="margin-right: 53px">
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="DNI">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexo">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nacionalidad">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha De Nac.">
                <ItemTemplate>
                    <asp:Label ID="lbl__it_fechaNac" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Direccion">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Correo Electronico">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_mail" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Provincia">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Localidad">
                <ItemTemplate>
                    <asp:Label ID="lbl_it_localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
   
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>
</asp:Content>
