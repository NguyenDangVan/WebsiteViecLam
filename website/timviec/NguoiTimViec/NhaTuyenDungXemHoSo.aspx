<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="NhaTuyenDungXemHoSo.aspx.cs" Inherits="timviec.NguoiTimViec.NhaTuyenDungXemHoSo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
    <div>
        &nbsp;&nbsp;<asp:LinkButton ID="lnkNTDXemHS_TuHoSo" runat="server" ForeColor="Black" OnClick="lnkNTDXemHS_TuHoSo_Click">Tủ hồ sơ</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNTDXemHS_TaiKhoan" runat="server" ForeColor="Black" OnClick="lnkNTDXemHS_TaiKhoan_Click">Tài khoản</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNTDXemHS_ViecLamUngTuyen" runat="server" ForeColor="Black" OnClick="lnkNTDXemHS_ViecLamUngTuyen_Click">Việc làm đã ứng tuyển</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNTDXemHS_NhaTuyenDungXemHoSo" runat="server" ForeColor="Black" OnClick="lnkNTDXemHS_NhaTuyenDungXemHoSo_Click">Nhà tuyển dụng đã xem hồ sơ</asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Nhà tuyển dụng đã xem hồ sơ</h3>
    </div>
    <asp:GridView ID="grvNTDXemHS_DSNTD" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TenCongTy" HeaderText="Tên công ty" />
            <asp:BoundField DataField="NgayXem" HeaderText="Ngày xem" DataFormatString="{0:d}" />
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
