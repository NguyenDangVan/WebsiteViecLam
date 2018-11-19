<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="timviec.LienHe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Liên hệ</h3>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Những mục có dấu (*) là bắt buộc phải nhập" ForeColor="Red"></asp:Label>
    <table style="width: 100%;">
        <tr>
            <td>
                Tiêu đề (*):
            </td>
            <td>
                <asp:TextBox ID="txtLienHe_TieuDe" runat="server" Height="30px" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Hộ tên (*):
            </td>
            <td>
                <asp:TextBox ID="txtLienHe_HoTen" runat="server" Height="30px" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email (*):
            </td>
            <td>
                <asp:TextBox ID="txtLienHe_Email" runat="server" Height="30px" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nội dung phản hồi (*):
            </td>
            <td>
                <asp:TextBox ID="txtLienHe_NoiDung" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnLienHe_Gui" runat="server" Text="Gửi" Height="35px" Width="80px" OnClick="btnLienHe_Gui_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnLienHe_Huy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnLienHe_Huy_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
