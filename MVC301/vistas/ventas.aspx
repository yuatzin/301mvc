<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="MVC301.vistas.ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID venta "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nombre del producto"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Nombre del Proveedor"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar" OnClick="Button1_Click"  />
            <asp:Button ID="Button5" runat="server" Text="Mostrar" OnClick="Button5_Click"  />
            <asp:Button ID="Button3" runat="server" Text="Borrar" OnClick="Button3_Click"   />
            <asp:Button ID="Button4" runat="server" Text="Modicar" OnClick="Button4_Click"   />
        </div>
    </form>
</body>
</html>
