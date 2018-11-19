<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="ChiTietViecLam.aspx.cs" Inherits="timviec.ChiTietViecLam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
</asp:Content>
<%--Chi tiết việc làm--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3><asp:Label ID="lblCTVL_TenViecLam" runat="server" Text=""></asp:Label></h3>
    </div>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCTVL_NgayDang" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCTVL_TenCTy" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCTVL_DiaChiCTy" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Số lượng:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_SoLuong" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Thời gian thử việc:</b>
                
            </td>
            <td>
                <asp:Label ID="lblCTVL_ThuViec" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Trình độ:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_TrinhDo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Giới tính:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_GioiTinh" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Kinh nghiệm:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_KinhNghiem" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Mức lương:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_MucLuong" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Vị trí làm việc:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_ViTri" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Ngành nghề:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_NganhNghe" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Tỉnh/Thành phố:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_ThanhPho" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Mô tả công việc:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_MoTa" runat="server" Height="150px" Width="380px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Yêu cầu:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_yeuCauKyNang" runat="server" Height="150px" Width="380px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Hồ sơ:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_HoSo" runat="server" Height="150px" Width="380px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Ngày hết hạn:</b>
            </td>
            <td>
                <asp:Label ID="lblCTVL_NgayHetHan" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnCTVL_NopHoSo" runat="server" Height="40px" Text="Nộp hồ sơ" Width="90px" OnClick="btnCTVL_NopHoSo_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
