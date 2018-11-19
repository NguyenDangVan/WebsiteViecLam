<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QL_NganhNghe.aspx.cs" Inherits="timviec.Admin.QL_NganhNghe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Quản lý loại ngành nghề</h2><br />
    <div style="width: 600px; height: auto; margin: auto;">
        <table style="width: 600px;">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblIDNghe" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblID_NganhNghe" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    
                    Loại ngành:</td>
                <td>
                    <asp:TextBox ID="txtTenNganh" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chưa nhập thông tin" ControlToValidate="txtTenNganh" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnHuy_Nganh" runat="server" Text="Thêm mới" Height="35px" Width="80px" OnClick="btnHuy_Nganh_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnLuu_Nganh" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnLuu_Nganh_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnSua_Nganh" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnSua_Nganh_Click" />
                </td>
            </tr>
        </table>
        <div>
            <img id="OK" runat="server" alt="" src="images/start.png" />
            <img id="Stop" runat="server" alt="" src="images/stop1.png" />
            <asp:Label ID="lblTB_NganhNghe" runat="server"></asp:Label>
        </div><br />
        <hr style="width: 500px; margin: auto" /><br />
        <center>
            <asp:GridView ID="grvLoaiNganh" runat="server" Width="550px" AutoGenerateColumns="false" GridLines="None" OnRowCommand="grvLoaiNganh_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_NganhNghe" HeaderText="Mã loại ngành" />
                <asp:BoundField DataField="TenNganhNghe" HeaderText="Tên ngành" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:LinkButton ID="Edit_LoaiNganh" runat="server" CommandArgument='<%#Eval("ID_NganhNghe") %>'
                            CommandName="cmdEdit_LoaiNganh" Text="Sửa">
                        </asp:LinkButton>
                        <asp:LinkButton ID="Delete_LoaiNganh" runat="server" CommandArgument='<%#Eval("ID_NganhNghe") %>'
                            CommandName="cmdDelete_LoaiNganh" Text="Xóa">
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
