using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace timviec
{
    public partial class dangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTimViec_Click(object sender, EventArgs e)
        {
            Response.Redirect("NguoiTimViec/DangKyTimViec.aspx");
        }

        protected void btnTuyenDung_Click(object sender, EventArgs e)
        {
            Response.Redirect("NhaTuyenDung/DangKyCongTy.aspx");
        }
    }
}