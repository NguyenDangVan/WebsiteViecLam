<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="TimKiemUngVien.aspx.cs" Inherits="NhaTuyenDung_TimKiemUngVien" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkTimUV_TimKiemUV" runat="server" ForeColor="Black" OnClick="lnkTimUV_TimKiemUV_Click">Tìm kiếm ứng viên</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTimUV_ThemViecLam" runat="server" ForeColor="Black" OnClick="lnkTimUV_ThemViecLam_Click">Thêm việc làm mới</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTimUV_DSViecLam" runat="server" ForeColor="Black" OnClick="lnkTimUV_DSViecLam_Click">Danh sách công việc</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkTimUV_UngVienDaUngTuyen" runat="server" ForeColor="Black" OnClick="lnkTimUV_UngVienDaUngTuyen_Click">Ứng viên đã ứng tuyển</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ddlTimUV_NganhNghe" runat="server" Width="150px"></asp:DropDownList>
    <asp:DropDownList ID="ddlTimUV_ThanhPho" runat="server" Width="150px"></asp:DropDownList>
    <asp:DropDownList ID="ddlTimUV_TrinhDo" runat="server" Width="150px"></asp:DropDownList>
    <asp:DropDownList ID="ddlTimUV_KinhNghiem" runat="server" Width="150px"></asp:DropDownList>
    <asp:Button ID="btnTimUV_TimKiem" runat="server" Text="Tìm kiếm" Width="65px" OnClick="btnTimUV_TimKiem_Click" />
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Danh sách các ứng viên</h3>
    </div>
    <asp:GridView ID="grvTimUV_DSUngVien" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="grvTimUV_DSUngVien_PageIndexChanging" OnRowCommand="grvTimUV_DSUngVien_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
            <%--<asp:BoundField DataField="TenNganhNghe" HeaderText="Ngành nghề" />--%>
            <asp:BoundField DataField="TieuDe" HeaderText="Công việc" />
            <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
            <asp:BoundField DataField="TenKinhNghiem" HeaderText="Kinh nghiệm" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="TimUV_DSUngVien" runat="server" CommandArgument='<%#Eval("ID_CV") %>'
                        CommandName="lbtTimUV_DSUngVien" Text="Chi tiết"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle ForeColor="Red" />
                <ItemStyle Width="50px" />
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
    <br />
    <div id="TimUV_ChiTietUngVien" runat="server" style="width: auto; height: auto">
        <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
            <h3>Thông tin ứng viên</h3>
        </div>
        <table style="width: 100%;">
            <tr>
                <td>Họ tên:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_HoTen" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ngày sinh:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_NgaySinh" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Giới tính:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_GioiTinh" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Địa chỉ:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_DiaChi" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_Email" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Số điện thoại:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_SDT" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Công việc mong muốn:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_TieuDe" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ngành nghề:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_NganhNghe" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Vị trí làm việc:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_ViTri" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Trình độ:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_TrinhDo" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Kinh nghiệm:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_KinhNghiem" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Kỹ năng:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_KyNang" runat="server" Height="150px" ReadOnly="True" TextMode="MultiLine" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Trình độ ngoại ngữ:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_NgoaiNgu" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mức lương mong muốn:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_MucLuong" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bằng cấp/chứng chỉ:</td>
                <td>
                    <asp:TextBox ID="txtTimUV_BangCap" runat="server" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnTimUV_OK" runat="server" Height="35px" Text="OK" Width="80px" OnClick="btnTimUV_OK_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

