<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admTop.ascx.cs" Inherits="timviec.Controll.admTop" %>
<div class="div">
    <table class="table" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3" class="logo">ADMIN PAGE MANAGER</td>
        </tr>
        <tr>
            <td class="left">Wellcome:
                <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="right">
                <asp:LinkButton ID="lbtTrangChu" runat="server">Trang chủ</asp:LinkButton>
            </td>
        </tr>
    </table>
</div>
