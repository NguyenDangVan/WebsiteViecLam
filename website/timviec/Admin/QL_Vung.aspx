<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QL_Vung.aspx.cs" Inherits="timviec.Admin.QL_Vung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý loại vùng miền</h2><br />
    <div style="width: 600px; height: auto; margin: auto;">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="lblTextIDVung" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_Vung" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Tên vùng:</td>
                <td>
                    <asp:TextBox ID="txtTenVung" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnVung_ThemMoi" runat="server" Height="35px" Text="Thêm mới" Width="80px" OnClick="btnVung_ThemMoi_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnVung_Luu" runat="server" Height="35px" Text="Lưu" Width="80px" OnClick="btnVung_Luu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnVung_Sua" runat="server" Height="35px" Text="Sửa" Width="80px" OnClick="btnVung_Sua_Click" />
                </td>
            </tr>
        </table>
        <div>
            <img id="OK" runat="server" alt="" src="images/start.png" />
            <img id="Stop" runat="server" alt="" src="images/stop1.png" />
            <asp:Label ID="lblTB_Vung" runat="server"></asp:Label>
        </div><br />
        <hr style="width: 500px; margin: auto" /><br />
        <center>
            <asp:GridView ID="grvVung" runat="server" Width="550px" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvVung_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_Vung" HeaderText="Mã vùng" />
                <asp:BoundField DataField="TenVung" HeaderText="Tên vùng" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_Vung" runat="server" CommandArgument='<%#Eval("ID_Vung") %>'
                            CommandName="cmdEdit_Vung" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_Vung" runat="server" CommandArgument='<%#Eval("ID_Vung") %>'
                            CommandName="cmdDelete_Vung" Text="Xóa">
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
        </center>
    </div>
</asp:Content>
