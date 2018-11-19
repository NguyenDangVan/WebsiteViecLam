<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViecLamChuaDuyet.aspx.cs" Inherits="timviec.Admin.ViecLamChuaDuyet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Danh sách các việc làm chưa được duyệt</h2>
    <br />
    <center>
        <asp:GridView ID="grvDS_ViecLamChuaDuyet" runat="server" Width="1000px" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnPageIndexChanging="grvDS_ViecLamChuaDuyet_PageIndexChanging" OnRowCommand="grvDS_ViecLamChuaDuyet_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID_ViecLam" HeaderText="Mã việc làm" />
                <asp:BoundField DataField="TieuDeViecLam" HeaderText="Tên công việc" />
                <asp:BoundField DataField="TenCongTy" HeaderText="Công ty" />
                <asp:BoundField DataField="TenNganhNghe" HeaderText="Ngành nghề" />
                <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
                <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" DataFormatString="{0:d}" />
                <asp:BoundField DataField="NgayHetHan" HeaderText="Ngày hết hạn" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Xử lý">
                    <ItemTemplate>
                        <asp:Button ID="Edit_DuyetViecLam" runat="server" CommandArgument='<%#Eval("ID_ViecLam") %>'
                            CommandName="btnEdit_DuyetViecLam" Text="Select"></asp:Button>
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
    <br />
    <hr style="width: 600px; margin: auto" />
    <br />
    <div id="IDViecLamChuaDuyet"  runat="server" style="width: 700px; height: auto; margin: auto">
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right">
                    Mã việc làm:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_MaVL" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Tên công ty:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_TenCT" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Tên công việc:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_TenVL" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Ngành nghề:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_NganhNghe" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Vị trí:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_ViTri" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Trình độ:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_TrinhDo" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Giới tính:
                </td>
                <td>
                    
                    <asp:TextBox ID="txtDuyetVL_GioiTinh" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Mô tả:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_MoTa" runat="server" Height="150px" Width="380px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Yêu cầu kỹ năng:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_YeuCauKyNang" runat="server" Height="150px" Width="380px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Yêu cầu hồ sơ:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_YeuCauHoSo" runat="server" Height="150px" Width="380px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Số lượng:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_SoLuong" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Ngày đăng:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_NgayDang" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Ngày hết hạn:
                </td>
                <td>

                    <asp:TextBox ID="txtDuyetVL_NgayHetHan" runat="server" Height="30px" Width="250px" ReadOnly="True"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnDuyetViecLam" runat="server" Height="35px" Text="Duyệt" Width="80px" OnClick="btnDuyetViecLam_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
