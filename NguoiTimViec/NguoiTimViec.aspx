<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="NguoiTimViec.aspx.cs" Inherits="NguoiTimViec_NguoiTimViec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkTuHoSo" runat="server" ForeColor="Black" OnClick="lnkTuHoSo_Click">Tủ hồ sơ</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTaiKhoan" runat="server" ForeColor="Black" OnClick="lnkTaiKhoan_Click">Tài khoản</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkViecLamUngTuyen" runat="server" ForeColor="Black" OnClick="lnkViecLamUngTuyen_Click">Việc làm đã ứng tuyển</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNhaTuyenDungXemHoSo" runat="server" ForeColor="Black" OnClick="lnkNhaTuyenDungXemHoSo_Click">Nhà tuyển dụng đã xem hồ sơ</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ThongTinCaNhan" runat="server" style="width: 600px; height: auto; margin: auto; font-size: 16px; padding-left: 20px; padding-top: 10px;">
        <h3>Thông tin cá nhân</h3>
        <b>
            <asp:Label ID="Label1" runat="server" Text="Họ tên"></asp:Label></b>:
        <asp:Label ID="lblHoTen" runat="server" Text=""></asp:Label><br />
        <b>
            <asp:Label ID="Label2" runat="server" Text="Giới tính"></asp:Label></b>:
        <asp:Label ID="lblGioiTinh" runat="server" Text=""></asp:Label><br />
        <b>
            <asp:Label ID="Label3" runat="server" Text="Ngày sinh"></asp:Label></b>:
        <asp:Label ID="lblNgaySinh" runat="server" Text=""></asp:Label><br />
        <b>
            <asp:Label ID="Label4" runat="server" Text="Địa chỉ"></asp:Label></b>:
        <asp:Label ID="lblDiaChi" runat="server" Text=""></asp:Label><br />
        <b>
            <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label></b>:
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br />
        <b>
            <asp:Label ID="Label6" runat="server" Text="Số điện thoại"></asp:Label></b>:
        <asp:Label ID="lblSDT" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnUV_XemCV" runat="server" Height="35px" Text="Xem CV" Width="80px" OnClick="btnUV_XemCV_Click" />
        <br />
        <br />
        <div id="UV_HoSoUngVien" runat="server" style="width:auto; height:auto; margin:auto">
            <hr style="width: 500px; margin: auto; background-color: #808080;" />
            <h3>Hồ sơ của Ứng Viên</h3>

            <div style="width: auto; height: auto; float: right; margin-bottom: 10px;">
                <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label><br />
            </div>
            <asp:Label ID="lblID_CVUngVien" runat="server" Visible="False"></asp:Label>
            <table style="width: 100%;">
                <tr>
                    <td class="a">Tiêu đề:</td>
                    <td>
                        <asp:TextBox ID="txtUV_TieuDe" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Ngành nghề:</td>
                    <td>
                        <asp:DropDownList ID="ddlUV_NganhNghe" runat="server" Height="30px" Width="225px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Vị trí:</td>
                    <td>
                        <asp:DropDownList ID="ddlUV_ViTri" runat="server" Height="30px" Width="225px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="a">Trình độ:</td>
                    <td>
                        <asp:DropDownList ID="ddlUV_TrinhDo" runat="server" Height="30px" Width="225px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Kinh nghiệm:</td>
                    <td>
                        <asp:DropDownList ID="ddlUV_KinhNghiem" runat="server" Height="30px" Width="225px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Kỹ năng:</td>
                    <td>
                        <asp:TextBox ID="txtUV_KyNang" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Trình độ ngoại ngữ:</td>
                    <td>
                        <asp:TextBox ID="txtUV_NgoaiNgu" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Mức lương:</td>
                    <td>
                        <asp:DropDownList ID="ddlUV_MucLuong" runat="server" Height="30px" Width="225px">
                            <asp:ListItem>1 - 3 trieu</asp:ListItem>
                            <asp:ListItem>3 - 5 trieu</asp:ListItem>
                            <asp:ListItem>5 - 8 trieu</asp:ListItem>
                            <asp:ListItem>8 - 10 trieu</asp:ListItem>
                            <asp:ListItem>Trên 10 trieu</asp:ListItem>
                            <asp:ListItem>Thoa thoan</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Bằng cấp/Chứng chỉ:</td>
                    <td>
                        <asp:TextBox ID="txtUV_BangCap" runat="server" Height="150px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                    <asp:Button ID="btnUV_Luu" runat="server" Text="Lưu" Height="35px" Width="80px" OnClick="btnUV_Luu_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnUV_CapNhat" runat="server" Text="Cập nhật" Height="35px" Width="80px" OnClick="btnUV_CapNhat_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnUV_Xoa" runat="server" Text="Xóa CV" Height="35px" Width="80px" OnClick="btnUV_Xoa_Click" />&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

