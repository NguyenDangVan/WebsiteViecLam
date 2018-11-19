<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DangNhapNguoiTimViec.aspx.cs" Inherits="timviec.NguoiTimViec.DangNhapNguoiTimViec" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">ĐĂNG NHẬP NGƯỜI TÌM VIỆC</div>
    <table style="width: 100%;">
        <tr>
            <td class="a">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail_NguoiTimViec" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail_NguoiTimViec" ErrorMessage="Sai định dạng email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtMKNguoiTimViec" runat="server" Height="30px" Width="220px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMKNguoiTimViec" ErrorMessage="Chưa nhập mật khẩu" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnDNNguoiTimViec" runat="server" Text="Đăng nhập" Height="35px" Width="80px" OnClick="btnDNNguoiTimViec_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnHuy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnHuy_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuDangNhap" runat="server">
    
</asp:Content>
