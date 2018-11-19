<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSach-UngVien.aspx.cs" Inherits="timviec.Admin.DanhSach_CV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Danh sách Ứng Viên</h2><br />
    <div style="width: 100%; height: auto; margin: auto;">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Tên ứng viên" Font-Size="11pt" Height="30px" Width="100px"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtUV_TenUV" runat="server" Height="30px" Width="220px"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnUV_TimUV" runat="server" Text="Tìm kiếm" Height="35px" OnClick="btnUV_TimUV_Click" Width="80px" />

            <asp:GridView ID="grvDS_UngVien" runat="server" Width="1000px" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnPageIndexChanging="grvDS_UngVien_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_UngVien" HeaderText="Mã ứng viên" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:d}" />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </center>
    </div>
</asp:Content>
