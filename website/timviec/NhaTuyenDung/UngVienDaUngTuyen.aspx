<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="UngVienDaUngTuyen.aspx.cs" Inherits="timviec.NhaTuyenDung.UngVienDaUngTuyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkUVUngTuyen_TimKiemUV" runat="server" ForeColor="Black" OnClick="lnkUVUngTuyen_TimKiemUV_Click">Tìm kiếm ứng viên</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkUVUngTuyen_ThemViecLam" runat="server" ForeColor="Black" OnClick="lnkUVUngTuyen_ThemViecLam_Click">Thêm việc làm mới</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkUVUngTuyen_DSViecLam" runat="server" ForeColor="Black" OnClick="lnkUVUngTuyen_DSViecLam_Click">Danh sách công việc</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkUVUngTuyen_UngVienDaUngTuyen" runat="server" ForeColor="Black" OnClick="lnkUVUngTuyen_UngVienDaUngTuyen_Click">Ứng viên đã ứng tuyển</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Danh sách các ứng viên đã ứng tuyển</h3>
    </div>
    <asp:GridView ID="grvUVUngTuyen_DSUVUngTuyen" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" AllowPaging="True" 
        OnPageIndexChanging="grvUVUngTuyen_DSUVUngTuyen_PageIndexChanging" OnRowCommand="grvUVUngTuyen_DSUVUngTuyen_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
            <asp:BoundField DataField="TieuDeViecLam" HeaderText="Công việc" />
            <asp:BoundField DataField="NgayUngTuyen" HeaderText="Ngày nộp" DataFormatString="{0:d}" />
            <asp:BoundField DataField="TenKinhNghiem" HeaderText="Kinh nghiệm" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="Xem_UVUngTuyen_DSUVUngTuyen" runat="server" CommandArgument='<%#Eval("ID_DangKy") %>'
                        CommandName="lbtXem_UVUngTuyen_DSUVUngTuyen" Text="Xem"></asp:LinkButton>
                    <asp:LinkButton ID="Xoa_UVUngTuyen_DSUVUngTuyen" runat="server" CommandArgument='<%#Eval("ID_DangKy") %>'
                        CommandName="lbtXoa_UVUngTuyen_DSUVUngTuyen" Text="Xóa"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle ForeColor="Red" />
                <ItemStyle Width="60px" />
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
    <div id="UVUngTuyen_ChiTiet" runat="server" style="width: auto; height: auto">
        <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
            <h3>Thông tin ứng viên ứng tuyển vị trí: <asp:Label ID="lblUVUngTuyen_TieuDeVieclam" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <table style="width: 100%;">
            <tr>
                <td>Họ tên:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_HoTen" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ngày sinh:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_NgaySinh" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Giới tính:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_GioiTinh" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Địa chỉ:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_DiaChi" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_Email" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Số điện thoại:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_SDT" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Công việc mong muốn:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_TieuDe" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Vị trí làm việc:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_ViTri" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Trình độ:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_TrinhDo" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Kinh nghiệm:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_KinhNghiem" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Yêu cầu công việc</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_YeuCauKyNang" runat="server" Height="150px" ReadOnly="True" TextMode="MultiLine" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Kỹ năng:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_KyNang" runat="server" Height="150px" ReadOnly="True" TextMode="MultiLine" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Trình độ ngoại ngữ:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_NgoaiNgu" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mức lương mong muốn:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_MucLuong" runat="server" Height="30px" ReadOnly="True" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bằng cấp/chứng chỉ:</td>
                <td>
                    <asp:TextBox ID="txtUVUngTuyen_BangCap" runat="server" Height="100px" ReadOnly="True" TextMode="MultiLine" Width="450px"></asp:TextBox>
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
