<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="abmlPacientes.aspx.cs" Inherits="Vistas.AbmlPacientes" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <h1>PACIENTES</h1>
    <asp:Button ID="btnAgregarPaciente" runat="server" OnClick="btnAgregarPaciente_Click" Text="Agregar Nuevo Paciente" />
    &nbsp;&nbsp;
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
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
            <td><asp:DropDownList ID="ddlNacionalidad" runat="server" >
                <asp:ListItem>Argentino</asp:ListItem>
                <asp:ListItem>Chileno</asp:ListItem>
                <asp:ListItem>Paraguayo</asp:ListItem>
                <asp:ListItem>Boliviano</asp:ListItem>
                <asp:ListItem>Uruguayo</asp:ListItem>
                <asp:ListItem>Brasilero</asp:ListItem>
                </asp:DropDownList>
            </td>
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
            <td style="text-align: right">&nbsp;<asp:Button ID="btnAgregar" runat="server" style="text-align: right" Text="Agregar" OnClick="btnAgregar_Click" />
            </td>
        </tr>
    </table>

    <br />
     
        <div class="container mt-4">
            <!-- Filter Area Box Container -->
            <div class="card shadow-sm p-4 bg-light" style="max-width: 500px;">
                <h5 class="card-title mb-3 text-secondary">Filtros y Búsqueda</h5>
                
                <!-- Floating Label Group -->
                <div class="form-floating mb-3">
                    <!-- The TextBox must have placeholder text for the floating effect to work -->
                    <asp:TextBox 
                        ID="txtBuscarDNI" 
                        runat="server" 
                        CssClass="form-control" 
                        placeholder="12345678"
                        data-bs-toggle="popover" data-bs-trigger="hover focus" data-bs-content="Ejemplo: 12345678"
                        />
                    
                    <!-- Dynamic client ID linkage -->
                    <label for="<%= txtBuscarDNI.ClientID %>">Buscar por DNI</label>
                </div>

                <!-- Action Button -->
                <asp:Button 
                    ID="btnBuscar" 
                    runat="server" 
                    Text="Buscar" 
                    CssClass="btn btn-primary px-4" />
            </div>
        </div>

    <br /><br />
    <asp:GridView ID="gvPacientes" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="DNI"
        AllowPaging="True" PageSize="8"
        OnPageIndexChanging="gvPacientes_PageIndexChanging"    
        GridLines="None"
        Width="900px" 
        Font-Names="Arial" Font-Size="Small"
        EmptyDataText="No se encontraron pacientes." CellPadding="4" ForeColor="#333333" style="margin-right: 53px" AutoGenerateEditButton="True" OnRowCancelingEdit="gvPacientes_RowCancelingEdit" OnRowEditing="gvPacientes_RowEditing" OnRowUpdating="gvPacientes_RowUpdating" OnRowDataBound="gvPacientes_RowDataBound">
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="DNI">
                <EditItemTemplate>
                    <asp:Label ID="lbl_eit_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eit_nombrePaciente" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexo">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_eit_Sexo" runat="server" SelectedValue='<%# Bind("Sexo") %>'>
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nacionalidad">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_eit_nacionalidad" runat="server">
                        <asp:ListItem>Argentino</asp:ListItem>
                        <asp:ListItem>Chileno</asp:ListItem>
                        <asp:ListItem>Paraguayo</asp:ListItem>
                        <asp:ListItem>Boliviano</asp:ListItem>
                        <asp:ListItem>Uruguayo</asp:ListItem>
                        <asp:ListItem>Brasilero</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha De Nac.">
                <EditItemTemplate>
                    <asp:TextBox ID="text_eit_Nacimiento" runat="server" TextMode="Date" Text='<%# Bind("FechaNacimiento", "{0:yyyy-MM-dd}") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl__it_fechaNac" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Direccion">
                <EditItemTemplate>
                    <asp:TextBox ID="text_eit_Direccion" runat="server" Text='<%# Bind("Direccion") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Correo Electronico">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eit_Correo" runat="server" TextMode="Email" Text='<%# Bind("CorreoElectronico") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_mail" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Provincia">
                <EditItemTemplate>
                    <asp:DropDownList
                        ID="ddl_eit_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincia_SelectedIndexChanged">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_Provincia" runat="server"
                        Text='<%# Bind("Provincia") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Localidad">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_eit_Localidad" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_it_localidad" runat="server"
                        Text='<%# Bind("Localidad") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_eit_estado" runat="server">
                        <asp:ListItem Text="Activo" Value="True"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="False"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# (Convert.ToBoolean(Eval("Estado")) ? "Activo" : "Inactivo") %>' />
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
    <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>
</asp:Content>
