<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="DangKy.aspx.cs" Inherits="DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
        <div id="login-timviec">          
            <div style="text-align:center; margin-top:10px"><img src="Images/tim-viec.png" style="height:120px;" /></div><br />
            <div style="text-align:center"><asp:Button ID="btnTimViec" runat="server" Text="Đăng ký Người Tìm Việc" Height="35px" Width="230px" OnClick="btnTimViec_Click"  /><%--OnClick="btnTimViec_Click"--%></div>
        </div>
        <div id="login-tuyendung">
            <div style="text-align:center; margin-top:10px"><img src="Images/tuyen-dung.png" style="height:120px" /></div><br />
            <div style="text-align:center"><asp:Button ID="btnTuyenDung" runat="server" Text="Đăng ký Nhà Tuyển Dụng" Height="35px" Width="230px" OnClick="btnTuyenDung_Click"  /><%--OnClick="btnTuyenDung_Click"--%></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

