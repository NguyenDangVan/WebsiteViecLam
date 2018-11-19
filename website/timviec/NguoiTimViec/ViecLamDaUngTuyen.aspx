<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="ViecLamDaUngTuyen.aspx.cs" Inherits="timviec.NguoiTimViec.ViecLamDaUngTuyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkVLDaUngTuyen_TuHoSo" runat="server" ForeColor="Black" OnClick="lnkVLDaUngTuyen_TuHoSo_Click">Tủ hồ sơ</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVLDaUngTuyen_TaiKhoan" runat="server" ForeColor="Black" OnClick="lnkVLDaUngTuyen_TaiKhoan_Click">Tài khoản</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVLDaUngTuyen_ViecLamUngTuyen" runat="server" ForeColor="Black" OnClick="lnkVLDaUngTuyen_ViecLamUngTuyen_Click">Việc làm đã ứng tuyển</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkVLDaUngTuyen_NhaTuyenDungXemHoSo" runat="server" ForeColor="Black" OnClick="lnkVLDaUngTuyen_NhaTuyenDungXemHoSo_Click">Nhà tuyển dụng đã xem hồ sơ</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Việc làm đã ứng tuyển</h3>
    </div>
    <asp:GridView ID="grvNTDXemHS_DSNTD" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TieuDeViecLam" HeaderText="Tên công việc" />
            <asp:BoundField DataField="TenCongTy" HeaderText="Công ty" />
            <asp:BoundField DataField="NgayUngTuyen" HeaderText="Ngày ứng tuyển" DataFormatString="{0:d}" />
            <asp:TemplateField HeaderText="Xử lý">
                <ItemTemplate>
                    <asp:LinkButton ID="NTDXemHS_DSViecLam" runat="server" CommandArgument='<%#Eval("ID_DangKy") %>'
                        CommandName="btnNTDXemHS_DSViecLam" Text="Xóa"></asp:LinkButton>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
