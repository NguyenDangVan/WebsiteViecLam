<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DangKyTimViec.aspx.cs" Inherits="timviec.NguoiTimViec.DangKyTimViec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">ĐĂNG KÝ ỨNG VIÊN</div>
    <table style="width: 100%;">
        <tr>
            <td class="a">Họ tên:</td>
            <td><asp:TextBox ID="txtHoTen" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoTen" ErrorMessage="Chưa nhập họ tên" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Email:</td>
            <td><asp:TextBox ID="txtEmailUV" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailUV" ErrorMessage="Sai định dạng email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Mật khẩu:</td>
            <td><asp:TextBox ID="txtMatKhauUV" runat="server" Height="30px" Width="220px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMatKhauUV" ErrorMessage="Chưa nhập mật khẩu" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Địa chỉ:</td>
            <td><asp:TextBox ID="txtDiaChiUV" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDiaChiUV" ErrorMessage="Chưa nhập địa chỉ" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Thành phố:</td>
            <td>
                <asp:DropDownList ID="ddlDK_ThanhPho" runat="server" Height="30px" Width="225px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="a">Ngày sinh:</td>
            <td><asp:TextBox ID="txtNgaySinh" runat="server" Height="30px" Width="220px" TextMode="Date" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNgaySinh" ErrorMessage="Chưa chọn ngày sinh" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Giới tính:</td>
            <td><asp:DropDownList ID="ddlGioiTinh" runat="server" Height="30px" Width="225px">
                <asp:ListItem>Nam</asp:ListItem>
                <asp:ListItem>Nữ</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="a">Số điện thoại:</td>
            <td><asp:TextBox ID="txtSDTUV" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDTUV" ErrorMessage="Sai định dạng số điện thoại" ForeColor="Red" ValidationExpression="0\d{9,10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnDangKyUngVien" runat="server" Text="Đăng ký" Height="30px" Width="80px" OnClick="btnDangKyUngVien_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnHuyUngVien" runat="server" Text="Hủy" Height="30px" Width="80px" OnClick="btnHuyUngVien_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
