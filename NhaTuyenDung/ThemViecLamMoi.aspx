<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="ThemViecLamMoi.aspx.cs" Inherits="NhaTuyenDung_ThemViecLamMoi" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkVL_TimKiemUV" runat="server" ForeColor="Black" OnClick="lnkVL_TimKiemUV_Click">Tìm kiếm ứng viên</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVL_ThemViecLam" runat="server" ForeColor="Black" OnClick="lnkVL_ThemViecLam_Click">Thêm việc làm mới</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVL_DSViecLam" runat="server" ForeColor="Black" OnClick="lnkVL_DSViecLam_Click" >Danh sách công việc</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVL_UngVienDaUngTuyen" runat="server" ForeColor="Black" OnClick="lnkVL_UngVienDaUngTuyen_Click">Ứng viên đã ứng tuyển</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 600px; height: auto; margin: auto; font-size: 16px; padding-left: 20px; padding-top: 10px;">
        <h3>Thêm công việc mới</h3><br />
        <table style="width: 100%;">
            <tr>
                <td class="a">
                    Tên công việc:
                </td>
                <td>
                    <asp:TextBox ID="txtVL_TenVieclam" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Ngành nghề:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_NganhNghe" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Vị trí:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_ViTri" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Trinh độ:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_TrinhDo" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Kinh nghiệm:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_KinhNghiem" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Giới tính:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_GioiTinh" runat="server" Height="30px" Width="225px">
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
                    <asp:TextBox ID="txtVL_SoLuong" runat="server" Height="30px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Mô tả công việc:
                </td>
                <td>
                    <asp:TextBox ID="txtVL_MoTa" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Yêu cầu:
                </td>
                <td>
                    <asp:TextBox ID="txtVL_YeuCau" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Thời gian thử việc:
                </td>
                <td>
                    <asp:DropDownList ID="ddlVL_ThuViec" runat="server" Height="30px" Width="225px">
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
                    <asp:DropDownList ID="ddlVL_MucLuong" runat="server" Height="30px" Width="225px">
                        <asp:ListItem>1 - 3 triệu</asp:ListItem>
                        <asp:ListItem>3 - 5 triệu</asp:ListItem>
                        <asp:ListItem>5 - 8 triệu</asp:ListItem>
                        <asp:ListItem>8 - 10 triệu</asp:ListItem>
                        <asp:ListItem>Trên 10 triệu</asp:ListItem>
                        <asp:ListItem>Thỏa thuận</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Hồ sơ:
                </td>
                <td>
                    <asp:TextBox ID="txtVL_HoSo" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="a">
                    Ngày hết hạn:
                </td>
                <td>
                    <asp:TextBox ID="txtVL_NgayHetHan" runat="server" Height="30px" TextMode="Date" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnVL_Luu" runat="server" Text="Lưu" Height="35px" OnClick="btnVL_Luu_Click" Width="80px" />&nbsp;&nbsp;
                    <asp:Button ID="btnVL_Huy" runat="server" Text="Hủy" Height="35px" OnClick="btnVL_Huy_Click" Width="80px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

