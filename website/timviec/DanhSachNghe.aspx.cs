using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data;
using DAL;
using BLL;

namespace timviec
{
    public partial class DanhSachNghe : System.Web.UI.Page
    {
        TimViecDBDataContext data = new TimViecDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DSNghe();
            }
        }

        //danh sách nghe
        private void DSNghe()
        {
            string str = "";
            var a = from n in data.NganhNghes
                    select n;
            //a = a.OrderByDescending(q => q.ID_NganhNghe).Skip(12).Take(12);
            str += "<ul>";
            foreach (var b in a)
            {

                str += "<li><a href='ChiTietNghe.aspx?IDNghe=" + b.ID_NganhNghe + "'>" + b.TenNganhNghe + "</a></li>";

            }
            str += "</ul>";
            DanhSachNghe_DSNghe.InnerHtml = str;
        }
    }
}