<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="QL_ViTriUngTuyen.aspx.cs" Inherits="Admin_QL_ViTriUngTuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý loại vị trí ứng tuyển</h2><br />
    <div style="width: 600px; height: auto; margin: auto;">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="lblTextIDViTri" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_ViTri" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Tên vị trí:
                </td>
                <td>
                    <asp:TextBox ID="txtViTri" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnVT_ThemMoi" runat="server" Text="Thêm mới" Height="35px" Width="80px" OnClick="btnVT_ThemMoi_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnVT_Luu" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnVT_Luu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnVT_Sua" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnVT_Sua_Click" />
                </td>
            </tr>
        </table>
        <div>
            <img id="OK" runat="server" alt="" src="images/start.png" />
            <img id="Stop" runat="server" alt="" src="images/stop1.png" />
            <asp:Label ID="lblTB_ViTri" runat="server"></asp:Label>
        </div><br />
        <hr style="width: 500px; margin: auto" /><br />
        <center>
            <asp:GridView ID="grvViTri" runat="server" Width="550px" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvViTri_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_ViTri" HeaderText="Mã vị trí" />
                <asp:BoundField DataField="TenViTri" HeaderText="Tên vị trí ứng tuyển" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_ViTri" runat="server" CommandArgument='<%#Eval("ID_ViTri") %>'
                            CommandName="cmdEdit_ViTri" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_ViTri" runat="server" CommandArgument='<%#Eval("ID_ViTri") %>'
                            CommandName="cmdDelete_ViTri" Text="Xóa">
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
