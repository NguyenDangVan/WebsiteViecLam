<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSach-CongTy.aspx.cs" Inherits="timviec.Admin.DanhSach_CongTy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Danh sách Công Ty</h2><br />
    <div style="width: 100%; height: auto; margin: auto;">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Tên công ty" Font-Size="11pt" Height="30px" Width="100px"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtCT_TenCT" runat="server" Height="30px" Width="220px"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnCT_TimCT" runat="server" Text="Tìm kiếm" Height="35px" Width="80px" OnClick="btnCT_TimCT_Click" />

            <asp:GridView ID="grvDS_CongTy" runat="server" Width="1050px" AutoGenerateColumns="false" GridLines="None" AllowPaging="True"
                PageSize="10" OnPageIndexChanging="grvDS_CongTy_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_CongTy" HeaderText="Mã công ty" />
                <asp:BoundField DataField="TenCongTy" HeaderText="Tên công ty" />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
                <asp:BoundField DataField="QuyMo" HeaderText="Quy mô" />
                <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="Website" HeaderText="Website" />
                <asp:BoundField DataField="NguoiDaiDien" HeaderText="Người đại diện" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
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
