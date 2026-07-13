<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="abmlMedicos.aspx.cs" Inherits="Vistas.AbmlMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 128px;
        }
        .auto-style4 {
            height: 26px;
            width: 128px;
        }
        .auto-style5 {
            width: 68px;
        }
        .auto-style6 {
            height: 26px;
            width: 68px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <h1>Médicos</h1>
    <asp:Button ID="btnAgregarMedico" runat="server" OnClick="btnAgregarMedico_Click" Text="Agregar Nuevo Medico" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar Usuario y contaseña" OnClick="btnModificarUsuario_Click" />
    <br />
    <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
    <br />
    <br />
    <table id="bloqueAgregarMedico" runat="server" visible="false" border="0">
        <tr>
            <td>DNI </td>
            <td>
                <asp:TextBox ID="txtDni" runat="server" MaxLength="8" />
            </td>
            <td>Especialidad</td>
            <td><asp:DropDownList ID="ddlEspecialidad" runat="server" >
                <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Nombre</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtNombre" runat="server" />
            </td>
            <td class="auto-style2">Apellido</td>
            <td class="auto-style2"><asp:TextBox ID="txtApellido" runat="server" style="margin-top: 0px" /></td>
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
            <td>Provincia</td>
            <td>
                <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
            <td>Localidad</td>
            <td><asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td>Teléfono</td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" Height="22px" />
            </td>
            <td>Correo</td>
            <td><asp:TextBox ID="txtCorreo" runat="server" /></td>
        </tr>
        <tr>
            <td class="auto-style2">Nacionalidad</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddlNacionalidad" runat="server" >
                <asp:ListItem>Argentina</asp:ListItem>
                <asp:ListItem>Chile</asp:ListItem>
                <asp:ListItem>Paraguay</asp:ListItem>
                <asp:ListItem>Bolivia</asp:ListItem>
                <asp:ListItem>Uruguay</asp:ListItem>
                <asp:ListItem>Brasil</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style2">Dirección</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Dias de Atención</td>
            <td>
                <asp:DropDownList ID="ddl_agregarDiasMedico" runat="server">
                    <asp:ListItem Value="">--</asp:ListItem>
                    <asp:ListItem Value="0">Lunes a Viernes</asp:ListItem>
                    <asp:ListItem Value="1">Martes a Sabados</asp:ListItem>
                    <asp:ListItem Value="2">Miercoles a Domingo</asp:ListItem>
                    <asp:ListItem Value="3">Jueves a Lunes</asp:ListItem>
                    <asp:ListItem Value="4">Viernes a Martes</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>Horarios</td>
            <td>
                <asp:DropDownList ID="ddl_agregarHorarioMedico" runat="server">
                    <asp:ListItem Value="">--</asp:ListItem>
                    <asp:ListItem Value="1">00:00 a 08:00</asp:ListItem>
                    <asp:ListItem Value="2">06:00 a 14:00</asp:ListItem>
                    <asp:ListItem Value="3">12:00 a 20:00</asp:ListItem>
                    <asp:ListItem Value="4">18:00 a 02:00</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Usuario</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
            <td>Contraseña</td>
            <td>
                <asp:TextBox ID="txtContrasena" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>Repita contraseña</td>
            <td>
                <asp:TextBox ID="txtContrasena2" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="cv_Contrasenia" runat="server" ControlToCompare="txtContrasena2" ControlToValidate="txtContrasena" ErrorMessage="Las contraseñas deben ser iguales"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
      
                <asp:Button ID="btnGuardarMedico" runat="server" Text="Guardar" OnClick="btnGuardarMedico_Click" />
      
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
            </td>
        </tr>
        </table>

    <table id="bloqueModificarUsuario" runat="server" visible="false" border="0">
        <tr>
            <td class="auto-style5">Legajo </td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_legajo_modificar" runat="server" MaxLength="8" />
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
      
                <asp:Button ID="btnCancelarUsuario" runat="server" OnClick="btnCancelarUsuario_Click" Text="Cancelar"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style4">
                <asp:GridView ID="gvEditarUsuario" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Legajo">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_legajoUsuario" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_it_Usuario" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contraseña">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_contrasena" runat="server" Text='<%# Bind("Contrasena") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
      
                <asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" Visible="false"/>
      
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
      
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        </table>

    <br />
    <asp:Label ID="lbl_Mensaje_busquedas" runat="server"></asp:Label>
    <br />

    Buscar por Legajo:&nbsp; <asp:TextBox ID="txtFiltrarLegajo" runat="server" Width="89px" />
    

    &nbsp;&nbsp;
    

    <asp:Button ID="btnBuscarLegajo" runat="server" OnClick="btnBuscarLegajo_Click" Text="Buscar" />
    

    &nbsp;&nbsp;&nbsp;&nbsp; Buscar por Apellido:&nbsp;
    <asp:TextBox ID="txtFiltrarApellido" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBuscarApellido" runat="server" OnClick="btnBuscarApellido_Click" Text="Buscar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Busca por Nombre:&nbsp;&nbsp;
    <asp:TextBox ID="txtFiltrarNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Button ID="btnBuscarNombre" runat="server" OnClick="btnBuscarNombre_Click" Text="Buscar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    

    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
    

    <br />
    <br />
    <table>
        <tr>
        <!-- Columna izquierda -->
        <td style="vertical-align:top; padding-right:20px;">
            Sexo:<br />
                <asp:RadioButtonList ID="rbSexo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbSexo_SelectedIndexChanged" Width="102px">
                    <asp:ListItem Value="M">Masculinos</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:RadioButtonList>
                Estado:<asp:RadioButtonList ID="rbEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbEstado_SelectedIndexChanged">
                <asp:ListItem Value="-1">Todos</asp:ListItem>
                <asp:ListItem Value="1">Activos</asp:ListItem>
                <asp:ListItem Value="0">Inactivos</asp:ListItem>
                </asp:RadioButtonList>
                Especialidad<br />
            <asp:RadioButtonList ID="rbEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbEspecialidad_SelectedIndexChanged">
                <asp:ListItem Value="Clinica Medica">Clinica Medica</asp:ListItem>
                <asp:ListItem Value="Pediatria">Pediatria</asp:ListItem>
                <asp:ListItem Value="Cardiologia">Cardiologia</asp:ListItem>
                <asp:ListItem Value="Dermatologia">Dermatologia</asp:ListItem>
                <asp:ListItem Value="Traumatologia">Traumatologia</asp:ListItem>
                <asp:ListItem Value="Ginecologia">Ginecologia</asp:ListItem>
            </asp:RadioButtonList>
        </td>

        <!-- Columna derecha -->
        <td style="vertical-align:top;">

                <asp:GridView ID="gvMedicos" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="DNI"
                AllowPaging="True" PageSize="8"
                OnPageIndexChanging="gvMedicos_PageIndexChanging"
                OnRowUpdating="gvMedicos_RowUpdating"
                OnRowEditing="gvMedicos_RowEditing"
                OnRowCancelingEdit="gvMedicos_RowCancelingEdit"
                OnRowDataBound="gvMedicos_RowDataBound"
                GridLines="None"
                Width="900px" 
                Font-Names="Arial" Font-Size="Small"
                EmptyDataText="No se encontraron medicos." CellPadding="4" ForeColor="#333333" style="margin-right: 53px" AutoGenerateEditButton="True">
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Legajo">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                            <asp:TextBox ID="txt_eit_nombreMedico" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
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
                    <asp:TemplateField HeaderText="Especialidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_especialidad" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dias de Atencion">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_diasAtencion" runat="server">
                                <asp:ListItem Value="0">Lunes a Viernes</asp:ListItem>
                                <asp:ListItem Value="1">Martes a Sabados</asp:ListItem>
                                <asp:ListItem Value="2">Miercoles a Domingo</asp:ListItem>
                                <asp:ListItem Value="3">Jueves a Lunes</asp:ListItem>
                                <asp:ListItem Value="4">Viernes a Martes</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_diasAtencion" runat="server"
                               Text='<%# Convert.ToInt32(Eval("DiasAtencion")) == 0 ? "Lunes a Viernes" :
                                         Convert.ToInt32(Eval("DiasAtencion")) == 1 ? "Martes a Sabados" :
                                         Convert.ToInt32(Eval("DiasAtencion")) == 2 ? "Miercoles a Domingo" :
                                         Convert.ToInt32(Eval("DiasAtencion")) == 3 ? "Jueves a Lunes" :
                                         Convert.ToInt32(Eval("DiasAtencion")) == 4 ? "Viernes a Martes" :
                                         ""
                            %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horarios">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_horarioAtencion" runat="server">
                                <asp:ListItem Value="0">00:00 a 08:00</asp:ListItem>
                                <asp:ListItem Value="1">06:00 a 14:00</asp:ListItem>
                                <asp:ListItem Value="2">12:00 a 20:00</asp:ListItem>
                                <asp:ListItem Value="3">18:00 a 02:00</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_horariosAtencion" runat="server" Text='<%#
                                         Convert.ToInt32(Eval("HorarioAtencion")) == 0 ? "00:00 a 08:00" :
                                         Convert.ToInt32(Eval("HorarioAtencion")) == 1 ? "06:00 a 14:00" :
                                         Convert.ToInt32(Eval("HorarioAtencion")) == 2 ? "12:00 a 20:00" :
                                         Convert.ToInt32(Eval("HorarioAtencion")) == 3 ? "18:00 a 02:00" :
                                         ""
                           %>'></asp:Label>
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
        </td>
        </tr>
    </table>

    <br />
    <br />

    <asp:HyperLink ID="lnkVolverMenu" runat="server" NavigateUrl="~/HomeAdmin.aspx">Volver al menú</asp:HyperLink>

</asp:Content>
