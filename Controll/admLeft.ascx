<%@ Control Language="C#" AutoEventWireup="true" CodeFile="admLeft.ascx.cs" Inherits="Controll_adminLeft" %>

<table class="table" cellspacing="0" cellpadding="0">
<tr>
    <td class="left"><img alt="" src="../Admin/images/blank.gif" /></td>
    <td>Quản lý tài khoản</td>
    <td class="image"><img alt="" id="imgdiv1" src="../Admin/images/closed.gif" onclick="toggleXPMenu('div1');"/></td>
    <td class="right"><img alt="" src="../Admin/images/blank.gif" /></td>
</tr>
</table>
<asp:Panel ID="div1" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="../Admin/images/icon_system.jpg"/>
            <asp:LinkButton ID="lbtConfig" CausesValidation="false" runat="server" >Cấu hình</asp:LinkButton>
        </li>
        <li>
            <img alt="" src="../Admin/images/icon_user.jpg"/>
            <asp:LinkButton ID="lbtUser" CausesValidation="false" runat="server" >Người dùng</asp:LinkButton>
        </li>
		<li>
            <img alt="" src="../Admin/images/icon_page.jpg"/>
            <asp:LinkButton ID="lbtDoiMatKhau" CausesValidation="false" runat="server" >Đổi mật khẩu</asp:LinkButton>
		</li>
        <li>
            <img alt="" src="../Admin/images/icon_page.jpg"/>
            <asp:LinkButton ID="lbtLoaiTaiKhoan" CausesValidation="false" runat="server" >Quản lý loại tài khoản</asp:LinkButton>
		</li>
        <li>
            <img alt="" src="../Admin/images/icon_page.jpg"/>
            <asp:LinkButton ID="lbtTaiKhoan" CausesValidation="false" runat="server" >Quản lý tài khoản</asp:LinkButton>
		</li>
    </ul>
</asp:Panel>
	<table class="table" cellspacing="0" cellpadding="0">
        <tr>
            <td class="left">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
            <td>Quản lý chung</td>
            <td class="image">
                <img alt="" id="imgdiv10" src="../Admin/images/closed.gif" onclick="toggleXPMenu('div10');"/>
            </td>
            <td class="right">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
        </tr>
	</table>
<asp:Panel ID="div10" CssClass="content" ClientIDMode="Static" runat="server">
    <ul> 
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_NganhNghe.aspx">Quản lý ngành nghề</a>
        </li> 
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_ThanhPho.aspx">Quản lý thành phố</a>
        </li>
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_TrinhDo.aspx">Quản lý trình độ</a>
        </li>
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_VungMien.aspx">Quản lý vùng miền</a>
        </li>
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_ViTriUngTuyen.aspx" >Quản lý vị trí ứng tuyển</a>
        </li>
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/QL_KinhNghiem.aspx">Quản lý kinh nghiệm</a>
        </li>
<%--        <li>
            <img alt="" src="../Admin/images/icon_pro.jpg"/>
            <asp:LinkButton ID="lbtNews" runat="server" >Danh sách tin</asp:LinkButton>
        </li>--%> 
    </ul>
</asp:Panel>
	
	<table class="table" cellspacing="0" cellpadding="0">
        <tr>
            <td class="left">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
            <td>Quản lý CV của ứng viên</td>
            <td class="image">
                <img alt="" id="imgdiv9" src="../Admin/images/closed.gif" onclick="toggleXPMenu('div9');"/>
            </td>
            <td class="right">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
        </tr>
    </table>
<asp:Panel ID="div9" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/DanhSach-UngVien.aspx">Danh sách Ứng Viên</a>
        </li> 
        <li>
            <img alt="" src="../Admin/images/icon_gpro.jpg"/>
            <a href="../Admin/CV-ChuaDuyet.aspx" >Các CV chưa được duyệt</a>&nbsp;&nbsp;
            <asp:Label ID="lblDemCV" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </li> 
    </ul>
     
     </asp:Panel>		
	<table class="table" cellspacing="0" cellpadding="0">
        <tr>
            <td class="left">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
            <td>Quản lý tin tức việc làm</td>
            <td class="image">
                <img alt="" id="imgdiv8" src="../Admin/images/closed.gif" onclick="toggleXPMenu('div8');"/>
            </td>
            <td class="right">
                <img alt="" src="../Admin/images/blank.gif" />
            </td>
        </tr>
	</table>
    <asp:Panel ID="div8" CssClass="content" ClientIDMode="Static" runat="server">
        <ul>
            <li>
                <img alt="" src="../Admin/images/icon_gpro.jpg"/>
                <%--<a href="../Admin/DanhSach-CongTy.aspx">Danh sách Nhà Tuyển Dụng</a>--%>
            </li> 
            <li>
                <img alt="" src="../Admin/images/icon_gpro.jpg"/>
                <%--<a href="../Admin/ViecLamChuaDuyet.aspx">Các tin chưa được duyệt</a>&nbsp;&nbsp;--%>
                <asp:Label ID="lblDemTT" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </li>
        </ul>
    </asp:Panel>
