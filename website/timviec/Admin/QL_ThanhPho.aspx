<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QL_ThanhPho.aspx.cs" Inherits="timviec.Admin.QL_ThanhPho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý thành phố</h2><br />
    <div style="width: 600px; height: auto; margin: auto;">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="lblTextID" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_ThanhPho" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">                
                    Chọn vùng:
                </td>
                <td>
                    <asp:DropDownList ID="ddlQL_Vung" runat="server" Height="30px" Width="225px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Thành phố:
                </td>
                <td>
                    <asp:TextBox ID="txtTenThanhPho" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenThanhPho" ErrorMessage="Chưa nhập tên thành phố" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">

                    <asp:Button ID="btnTP_ThemMoi" runat="server" Text="Thêm mới" Height="35px" Width="80px" OnClick="btnTP_ThemMoi_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnTP_Luu" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnTP_Luu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnTP_Sua" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnTP_Sua_Click" />

                </td>
            </tr>
        </table>
        <div>
            <img id="OK" runat="server" alt="" src="images/start.png" />
            <img id="Stop" runat="server" alt="" src="images/stop1.png" />
            <asp:Label ID="lblTB_TP" runat="server"></asp:Label>
        </div><br />
        <hr style="width: 500px; margin: auto" /><br />
        <center>
            <asp:GridView ID="grvThanhPho" runat="server" Width="550px" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvThanhPho_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_ThanhPho" HeaderText="Mã thành phố" />
                <asp:BoundField DataField="ID_Vung" HeaderText="Mã vùng" />
                <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_TP" runat="server" CommandArgument='<%#Eval("ID_ThanhPho") %>'
                            CommandName="cmdEdit_TP" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_TP" runat="server" CommandArgument='<%#Eval("ID_ThanhPho") %>'
                            CommandName="cmdDelete_TP" Text="Xóa">
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
