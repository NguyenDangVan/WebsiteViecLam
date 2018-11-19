<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="timviec.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
        <div id="login-timviec">          
            <div style="text-align:center; margin-top:10px"><img src="Images/tim-viec.png" style="height:120px;" /></div><br />
            <div style="text-align:center"><asp:Button ID="btnDNTimViec" runat="server" Text="Đăng nhập Người Tìm Việc" Height="35px" Width="230px" OnClick="btnDNTimViec_Click" /></div>
        </div>
        <div id="login-tuyendung">
            <div style="text-align:center; margin-top:10px"><img src="Images/tuyen-dung.png" style="height:120px" /></div><br />
            <div style="text-align:center"><asp:Button ID="btnDNTuyenDung" runat="server" Text="Đăng nhập Nhà Tuyển Dụng" Height="35px" Width="230px" OnClick="btnDNTuyenDung_Click" /></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
