<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="QL_TrinhDo.aspx.cs" Inherits="Admin_QL_TrinhDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý loại trình độ</h2><br />
    <div style="width: 600px; height: auto; margin: auto;">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="lblTextIDTrinhDo" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_TrinhDo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Trình độ:
                </td>
                <td>
                    <asp:TextBox ID="txtTrinhDo" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnTD_ThemMoi" runat="server" Text="Thêm mới" Height="35px" Width="80px" OnClick="btnTD_ThemMoi_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnTD_Luu" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnTD_Luu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnTD_Sua" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnTD_Sua_Click" />
                </td>
            </tr>
        </table>
        <div>
            <img id="OK" runat="server" alt="" src="images/start.png" />
            <img id="Stop" runat="server" alt="" src="images/stop1.png" />
            <asp:Label ID="lblTB_TrinhDo" runat="server"></asp:Label>
        </div><br />
        <hr style="width: 500px; margin: auto" /><br />
        <center>
            <asp:GridView ID="grvTrinhDo" runat="server" Width="550px" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvTrinhDo_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_TrinhDo" HeaderText="Mã trình độ" />
                <asp:BoundField DataField="TenTrinhDo" HeaderText="Tên trình độ" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_TrinhDo" runat="server" CommandArgument='<%#Eval("ID_TrinhDo") %>'
                            CommandName="cmdEdit_TrinhDo" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_TrinhDo" runat="server" CommandArgument='<%#Eval("ID_TrinhDo") %>'
                            CommandName="cmdDelete_TrinhDo" Text="Xóa">
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


