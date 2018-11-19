<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CV-ChuaDuyet.aspx.cs" Inherits="timviec.Admin.CV_ChuaDuyet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Danh sách các CV chưa được duyệt</h2>
    <br />
    <div style="width: 100%; height: auto; margin: auto;">
        <center>
            <asp:GridView ID="grvDS_CVChuaDuyet" runat="server" Width="1000px" AutoGenerateColumns="false" GridLines="None" AllowPaging="True"
                PageSize="10" OnPageIndexChanging="grvDS_CVChuaDuyet_PageIndexChanging" OnRowCommand="grvDS_CVChuaDuyet_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID_CV" HeaderText="Mã CV" />
                    <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                    <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" />
                    <asp:BoundField DataField="TenNganhNghe" HeaderText="Ngành nghề" />
                    <asp:BoundField DataField="TenTrinhDo" HeaderText="Trình độ" />
                    <asp:BoundField DataField="NgoaiNgu" HeaderText="Ngoại ngữ" />
                    <asp:BoundField DataField="MucLuong" HeaderText="Mức lương" />
                    <asp:BoundField DataField="BangCap" HeaderText="Nơi cấp bằng" />
                    <asp:TemplateField HeaderText="Xử lý">
                        <ItemTemplate>
                            <asp:Button ID="Edit_CV" runat="server" CommandArgument='<%#Eval("ID_CV") %>'
                                CommandName="btnEdit_CV" Text="Select"></asp:Button>
                        </ItemTemplate>
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
        </center>
        <br />
        <hr style="width: 600px; margin: auto" />
        <br />
        <div id="IDCVChuaDuyet" runat="server" style="width: 700px; height: auto; margin: auto">
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: right">Mã CV:</td>
                    <td>
                        <asp:Label ID="lblCV_ID" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Tiêu đề:</td>
                    <td>

                        <asp:TextBox ID="txtCV_TieuDe" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Ngành nghề:</td>
                    <td>

                        <asp:TextBox ID="txtCV_NganhNghe" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Vị trí:</td>
                    <td>

                        <asp:TextBox ID="txtCV_ViTri" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Trình độ:</td>
                    <td>

                        <asp:TextBox ID="txtCV_TrinhDo" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Kinh nghiệm:</td>
                    <td>

                        <asp:TextBox ID="txtCV_KinhNghiem" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Kỹ năng:</td>
                    <td>

                        <asp:TextBox ID="txtCV_KyNang" runat="server" Height="90px" ReadOnly="True" TextMode="MultiLine" Width="350px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Trình độ ngoại ngữ:</td>
                    <td>

                        <asp:TextBox ID="txtCV_NgoaiNgu" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Mức lương:</td>
                    <td>

                        <asp:TextBox ID="txtCV_MucLuong" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Nơi cấp bằng:</td>
                    <td>

                        <asp:TextBox ID="txtCV_Bang" runat="server" Height="30px" ReadOnly="True" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:Button ID="btnDuyetCV" runat="server" Text="Duyệt" Height="35px" Width="80px" OnClick="btnDuyetCV_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
