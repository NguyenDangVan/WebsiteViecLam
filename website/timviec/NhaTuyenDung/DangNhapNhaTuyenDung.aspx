<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DangNhapNhaTuyenDung.aspx.cs" Inherits="timviec.NhaTuyenDung.DangNhapNhaTuyenDung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">ĐĂNG NHẬP NHÀ TUYỂN DỤNG</div>
    <table style="width: 100%;">
        <tr>
            <td class="a">
                Tên đăng nhập:
            </td>
            <td>
                <asp:TextBox ID="txtCT_TenDangNhap" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCT_TenDangNhap" ErrorMessage="Chưa nhập tên đăng nhập" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">
                Mật khẩu:
            </td>
            <td>
                <asp:TextBox ID="txtCT_MatKhau" runat="server" Height="30px" Width="220px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCT_MatKhau" ErrorMessage="Chưa nhập mật khẩu" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnCT_DangNhap" runat="server" Text="Đăng nhập" Height="35px" Width="80px" OnClick="btnCT_DangNhap_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCT_Huy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnCT_Huy_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
