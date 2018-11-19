<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViecLamMoi.ascx.cs" Inherits="timviec.Controll.ViecLamMoi" %>

<style>
    .style {
        text-align:left;
    }
</style>
<div>
    <marquee direction="up" scrollamount="2" scrolldelay="40" scrollamount="1" truespeed="truespeed" onmouseover="this.stop()" onmouseout="this.start()" style=" height:300px; text-align: center">
        <div class="style">
            <asp:DataList ID="datalist1" runat="server" Width="100%">
                <ItemTemplate>
                    <div style="height:30px">                        
                        <div style="float:left">
                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Green" Text='<%#Bind("TieuDeViecLam") %>'></asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </marquee>
</div>