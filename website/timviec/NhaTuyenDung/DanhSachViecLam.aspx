<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DanhSachViecLam.aspx.cs" Inherits="timviec.NhaTuyenDung.DanhSachViecLam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkDSVL_TimKiemUV" runat="server" ForeColor="Black" OnClick="lnkDSVL_TimKiemUV_Click">Tìm kiếm ứng viên</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkDSVL_ThemViecLam" runat="server" ForeColor="Black" OnClick="lnkDSVL_ThemViecLam_Click">Thêm việc làm mới</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkDSVL_DSViecLam" runat="server" ForeColor="Black" OnClick="lnkDSVL_DSViecLam_Click">Danh sách công việc</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkDSVL_UngVienDaUngTuyen" runat="server" ForeColor="Black" OnClick="lnkDSVL_UngVienDaUngTuyen_Click">Ứng viên đã ứng tuyển</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Danh sách việc làm đã đăng</h3><br />
    <asp:GridView ID="grvDSVL_DSViecLam" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True" 
        OnPageIndexChanging="grvDSVL_DSViecLam_PageIndexChanging" OnRowCommand="grvDSVL_DSViecLam_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="ID_ViecLam" HeaderText="Mã việc làm" />--%>
            <asp:BoundField DataField="TieuDeViecLam" HeaderText="Tiêu đề" />
            <asp:BoundField DataField="TenNganhNghe" HeaderText="Ngành nghề" />
            <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
            <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="NgayHetHan" HeaderText="Ngày hết hạn" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="TrangThai" HeaderText="Kích hoạt" />
            <asp:TemplateField HeaderText="Xử lý">
                <ItemTemplate>
                    <asp:Button ID="EditDSVL_DSViecLam" runat="server" CommandArgument='<%#Eval("ID_ViecLam") %>'
                        CommandName="btnEditDSVL_DSViecLam" Text="Sửa"></asp:Button>
                    <asp:Button ID="DeleteDSVL_DSViecLam" runat="server" CommandArgument='<%#Eval("ID_ViecLam") %>'
                        CommandName="btnDeleteDSVL_DSViecLam" Text="Xóa"></asp:Button>
                </ItemTemplate>
                <ItemStyle Width="80px" />
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
    </asp:GridView><br />

    <div id="SuaDSVieclam" runat="server" style="width: 610px; height: auto; margin: auto; font-size: 16px; padding-left: 20px; padding-top: 10px;">
        <h3>Sửa công việc</h3><br />
        <table style="width: 100%;">
            <tr>
                <td class="a">
                    Mã việc làm:
                </td>
                <td>
                    <asp:Label ID="lblDSVL_IDVL" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Tên công việc:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_TenVieclam" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Ngành nghề:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_NganhNghe" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Vị trí:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_ViTri" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Trinh độ:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_TrinhDo" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Kinh nghiệm:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_KinhNghiem" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Giới tính:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_GioiTinh" runat="server" Height="30px" Width="225px">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                        <asp:ListItem>Không xác định</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Số lượng:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_SoLuong" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Mô tả:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_MoTa" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Yêu cầu:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_YeuCau" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Thời gian thử việc:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_ThuViec" runat="server" Height="30px" Width="225px">
                        <asp:ListItem>1 tháng</asp:ListItem>
                        <asp:ListItem>2 tháng</asp:ListItem>
                        <asp:ListItem>Nhân viên chính thức</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Mức lương:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDSVL_MucLuong" runat="server" Height="30px" Width="225px">
                        <asp:ListItem>1 - 3 triệu</asp:ListItem>
                        <asp:ListItem>3 - 5 triệu</asp:ListItem>
                        <asp:ListItem>5 - 8 triệu</asp:ListItem>
                        <asp:ListItem>8 - 10 triệu</asp:ListItem>
                        <asp:ListItem>Trên 10 triệu</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Hồ sơ:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_HoSo" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Ngày hết hạn:
                </td>
                <td>
                    <asp:TextBox ID="txtDSVL_NgayHetHan" runat="server" Height="30px" TextMode="Date" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnDSVL_Sua" runat="server" Text="Sửa" Height="35px" Width="80px" OnClick="btnDSVL_Sua_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnDSVL_Huy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnDSVL_Huy_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
