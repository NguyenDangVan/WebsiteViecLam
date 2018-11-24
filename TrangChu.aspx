<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Các ngành nghề mới nhất</h3>
    </div>
    <div id="TrangChu_DSNghe1" runat="server" style="width: 300px; height: auto; margin: auto; padding-left: 10px; float: left">
    </div>
    <div id="TrangChu_DSNghe2" runat="server" style="width: 300px; height: auto; margin: auto; padding-left: 10px; float: right">
    </div>
    <div style="width: 100%; height: auto; float: left; text-align: right">
        <a href="DanhSachNghe.aspx">Xem tất cả</a><br />
    </div>
    <br />
    <hr style="width: 600px; margin: auto;" />
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Các việc làm mới nhất</h3>
    </div>
    <asp:GridView ID="grvTrangChu_DSViecLam" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" AllowPaging="True" PageSize="15"
    OnPageIndexChanging="grvTrangChu_DSViecLam_PageIndexChanging" OnRowCommand="grvTrangChu_DSViecLam_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TieuDeViecLam" HeaderText="Tiêu đề" />
            <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
            <asp:BoundField DataField="MucLuong" HeaderText="Mức lương" />
            <asp:BoundField DataField="NgayHetHan" HeaderText="Hết hạn" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="ChiTietTrangChu_DSViecLam" runat="server" CommandArgument='<%#Eval("ID_ViecLam") %>'
                        CommandName="lbtChiTietTragChu_DSViecLam" Text="Chi tiết"></asp:LinkButton>
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
    <hr style="width: 600px; margin: auto;" />
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Nhà tuyển dụng mới nhất</h3>
    </div>
    <div id="TrangChu_NhaTuyenDungMoiNhat" runat="server" style="width: 500px; height: auto; margin: auto; padding-left: 10px; float: left">

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
