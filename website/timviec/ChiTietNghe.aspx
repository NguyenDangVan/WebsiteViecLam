﻿<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="ChiTietNghe.aspx.cs" Inherits="timviec.ChiTietNghe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: auto; height: auto; border-left: 5px solid red; padding: 0px 10px">
        <h3>Các việc làm theo ngành: <asp:Label ID="lblChiTietNghe_TenNghe" runat="server" Text=""></asp:Label></h3>
    </div>
    <asp:GridView ID="grvChiTietNghe_DSViecLam" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" AllowPaging="True" PageSize="25" OnPageIndexChanging="grvChiTietNghe_DSViecLam_PageIndexChanging" OnRowCommand="grvChiTietNghe_DSViecLam_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TieuDeViecLam" HeaderText="Tiêu đề" />
            <asp:BoundField DataField="TenThanhPho" HeaderText="Thành phố" />
            <asp:BoundField DataField="MucLuong" HeaderText="Mức lương" />
            <asp:BoundField DataField="NgayHetHan" HeaderText="Hết hạn" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="ChiTietNghe_DSViecLam" runat="server" CommandArgument='<%#Eval("ID_ViecLam") %>'
                        CommandName="lbtChiTietNghe_DSViecLam" Text="Chi tiết"></asp:LinkButton>
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