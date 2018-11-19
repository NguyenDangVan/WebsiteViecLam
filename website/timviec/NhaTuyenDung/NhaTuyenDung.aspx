<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="NhaTuyenDung.aspx.cs" Inherits="timviec.NhaTuyenDung.NhaTuyenDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkTD_TimKiemUV" runat="server" ForeColor="Black" OnClick="lnkTD_TimKiemUV_Click">Tìm kiếm ứng viên</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTD_ThemViecLam" runat="server" ForeColor="Black" OnClick="lnkTD_ThemViecLam_Click">Thêm việc làm mới</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTD_DSCongViec" runat="server" ForeColor="Black" OnClick="lnkTD_DSCongViec_Click">Danh sách công việc</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTD_UngVienDaUngTuyen" runat="server" ForeColor="Black" OnClick="lnkTD_UngVienDaUngTuyen_Click">Ứng viên đã ứng tuyển</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 600px; height: auto; margin: auto; font-size: 16px; padding-left: 20px; padding-top: 10px;">
        <h3>Thông tin công ty</h3>
        <div id="ThongTinCongTy" runat="server">
            <b>
                <asp:Label ID="Label1" runat="server" Text="Tên công ty:"></asp:Label></b>
            <asp:Label ID="lblNTD_TenCongTy" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label2" runat="server" Text="Địa chỉ:"></asp:Label></b>
            <asp:Label ID="lblNTD_DiaChi" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label4" runat="server" Text="Số điện thoại:"></asp:Label></b>
            <asp:Label ID="lblNTD_SDT" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label5" runat="server" Text="Website:"></asp:Label></b>
            <asp:Label ID="lblNTD_Website" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label6" runat="server" Text="Mô tả:"></asp:Label></b>
            <asp:Label ID="lblNTD_MoTa" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label7" runat="server" Text="Quy mô:"></asp:Label></b>
            <asp:Label ID="lblNTD_QuyMo" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label9" runat="server" Text="Email:"></asp:Label></b>
            <asp:Label ID="lblNTD_Email" runat="server" Text=""></asp:Label><br />
            <b>
                <asp:Label ID="Label11" runat="server" Text="Người đại diện:"></asp:Label></b>
            <asp:Label ID="lblNTD_NguoiDaiDien" runat="server" Text=""></asp:Label><br />
            <br />
            <asp:Button ID="btnNTD_CapNhat" runat="server" Text="Cập nhật" Height="35px" Width="80px" OnClick="btnNTD_CapNhat_Click" />

        </div>
        <div id="SuaThongTinCongTy" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="a">Tên công ty:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_TenCongTy" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Địa chỉ:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_DiaChi" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Thành phố:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNTD_ThanhPho" runat="server" Height="30px" Width="225px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Số điện thoại:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_SDT" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Website:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_Website" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Mô tả:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_MoTa" runat="server" Height="90px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Quy mô:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNTD_QuyMo" runat="server" Height="30px" Width="225px">
                            <asp:ListItem>Dưới 20 người</asp:ListItem>
                            <asp:ListItem>20 - 50 người</asp:ListItem>
                            <asp:ListItem>50 - 100 người</asp:ListItem>
                            <asp:ListItem>100 - 200 người</asp:ListItem>
                            <asp:ListItem>200 - 500 người</asp:ListItem>
                            <asp:ListItem>Trên 500 người</asp:ListItem>
                            <asp:ListItem>Không xác định</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="a">Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_Email" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="a">Người đại diện:
                    </td>
                    <td>
                        <asp:TextBox ID="txtNTD_NguoiDaiDien" runat="server" Height="30px" Width="220px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="a">
                        <asp:Button ID="btnNTD_DongY" runat="server" Height="35px" Text="Đồng Ý" Width="80px" OnClick="btnNTD_DongY_Click" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnNTD_Huy" runat="server" Text="Hủy" Height="35px" Width="80px" OnClick="btnNTD_Huy_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <hr style="width: 500px; margin: auto; background-color: #808080;" />
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
