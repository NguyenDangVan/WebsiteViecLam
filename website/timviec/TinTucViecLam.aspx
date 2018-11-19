<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="TinTucViecLam.aspx.cs" Inherits="timviec.TinTucViecLam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuDangNhap" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div style="width: auto; height: auto; margin-left: 10px">
                    <div id="Image_TinTuc" runat="server" style="float: left; width: auto; height: auto">
                        adsad
                    </div>
                    <div id="NoiDung_TinTuc" runat="server" style="float: left; margin-left: 10px; width: auto; height: auto">
                        <div id="TieuDe_TinTuc" runat="server" style="width: auto; height: auto">
                            <a href="#"><b style="color: blue">ádasdsadsa</b></a>
                        </div>
                        <div id="MoTa_TinTuc" runat="server" style="width: auto; height: auto; margin-top: 10px">
                            <p>ádasdsadsa</p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div style="overflow: hidden;">
            <asp:Repeater ID="rptPages" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage"
                        Style="padding: 1px 3px; margin: 1px; background: #ccc; border: solid 1px #666; font: 8pt tahoma;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
