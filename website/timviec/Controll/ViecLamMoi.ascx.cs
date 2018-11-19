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

namespace timviec.Controll
{
    public partial class ViecLamMoi : System.Web.UI.UserControl
    {
        private TinViecLamBLL vieclam = new TinViecLamBLL();
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            var kq = from n in data.TinViecLams
                     where (n.TrangThai == true && n.NgayHetHan > DateTime.Now)
                     select n;
            datalist1.DataSource = kq;
            datalist1.DataBind();
        }
    }
}