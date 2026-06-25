<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Vistas.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="auto-style1">
        <div class="auto-style1">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblogin" runat="server" Text="LOGIN"></asp:Label>
            <br />
        </div>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesion" CausesValidation="false" OnClick="btnIniciarSesion_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
