<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Admin</title>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login-admin">
        <div style="width:400px; height:auto; margin:auto">
            <h3>ĐĂNG NHẬP TRANG ADMIN</h3>
            <table style="width: 100%;">
                <tr>
                    <td class="a">User:</td>
                    <td><asp:TextBox ID="txtUser" runat="server" Height="30px" Width="220px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="a">Password:</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" Height="30px" Width="220px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAdm_DangNhap" runat="server" Text="Đăng nhập" Height="35px" Width="80px" OnClick="btnAdm_DangNhap_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnAdm_Huy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnAdm_Huy_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <img src="images/add.png" />
                        <asp:LinkButton ID="lbtAdm_DangKyTaiKhoan" runat="server" ForeColor="Black" OnClick="lbtAdm_DangKyTaiKhoan_Click">Đăng ký tài khoản mới</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
