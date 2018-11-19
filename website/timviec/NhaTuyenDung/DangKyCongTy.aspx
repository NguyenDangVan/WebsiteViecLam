<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="DangKyCongTy.aspx.cs" Inherits="timviec.NhaTuyenDung.DangKyCongTy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">ĐĂNG KÝ NHÀ TUYỂN DỤNG</div>
    <table style="width: 100%;">
        <tr>
            <td class="a">Tên Công Ty:</td>
            <td>
                <asp:TextBox ID="txtTenCongTy" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenCongTy" ErrorMessage="Chưa nhập tên công ty" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Thành phố: </td>
            <td>
                <asp:DropDownList ID="ddlThanhPho" runat="server" Height="30px" Width="225px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="a">Tên đăng nhập:</td>
            <td>
                <asp:TextBox ID="txtTenDNCongTy" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTenDNCongTy" ErrorMessage="Chưa nhập tên đăng nhập" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtMKCongTy" runat="server" Height="30px" TextMode="Password" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMKCongTy" ErrorMessage="Chưa nhập mật khẩu" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Địa chỉ:</td>
            <td>
                <asp:TextBox ID="txtDiaChiCongTy" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDiaChiCongTy" ErrorMessage="Chưa nhập địa chỉ" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Quy mô:</td>
            <td>
                <asp:DropDownList ID="ddlQuyMo" runat="server" Height="30px" Width="225px">
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
            <td class="a">Số điện thoại:</td>
            <td>
                <asp:TextBox ID="txtSDTCongTy" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSDTCongTy" ErrorMessage="Chưa nhập số điện thoại" ForeColor="Red" ValidationExpression="0\d{9,10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Website:</td>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Chưa nhập website công ty" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Mô tả:</td>
            <td>
                <asp:TextBox ID="txtMoTa" runat="server" Height="150px" TextMode="MultiLine" Width="340px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="a">Người đại diện:</td>
            <td>
                <asp:TextBox ID="txtNguoiDaiDien" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNguoiDaiDien" ErrorMessage="Chưa nhập tên người đại diện" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="a">Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="220px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Chưa nhập Email công ty" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnDangKyCongTy" runat="server" Text="Đăng ký" Height="30px" Width="80px" OnClick="btnDangKyCongTy_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnHuy" runat="server" Text="Hủy" Height="30px" Width="80px" OnClick="btnHuy_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
