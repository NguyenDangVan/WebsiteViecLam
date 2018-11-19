<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="LoaiTaiKhoan.aspx.cs" Inherits="timviec.Admin.LoaiTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý loại tài khoản</h2>
    <div style="width: 550px; height: auto; margin: auto">
        <table style="width: 550px;">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_LoaiTK" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Loại tài khoản</td>
                <td>
                    <asp:TextBox ID="txtTenLoaiTK" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnLuu_LoaiTK" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnLuu_LoaiTK_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnSua_LoaiTK" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnSua_LoaiTK_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnHuy_LoaiTK" runat="server" Text="Thêm mới" Height="35px" Width="80px" OnClick="btnHuy_LoaiTK_Click" />
                </td>
            </tr>
        </table>
        <img id="OK" runat="server" alt="" src="images/start.png" /><img id="Stop" runat="server" alt="" src="images/stop1.png" /><asp:Label ID="lblTB_LoaiTK" runat="server"></asp:Label><br />
        <hr style="width: 500px; margin: auto" />
        <br />
        <asp:GridView ID="grvLoaiTK" runat="server" Width="100%" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvLoaiTK_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_LoaiTaiKhoan" HeaderText="Mã loại tài khoản" />
                <asp:BoundField DataField="TenLoai" HeaderText="Tên loại tài khoản" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_LoaiTK" runat="server" CommandArgument='<%#Eval("ID_LoaiTaiKhoan") %>'
                            CommandName="cmdEdit_LoaiTK" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_LoaiTK" runat="server" CommandArgument='<%#Eval("ID_LoaiTaiKhoan") %>'
                            CommandName="cmdDelete_LoaiTK" Text="Xóa">
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
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
    </div>
</asp:Content>
