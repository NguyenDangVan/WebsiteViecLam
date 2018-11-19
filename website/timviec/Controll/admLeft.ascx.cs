using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;
using BLL;

namespace timviec.Controll
{
    public partial class admLeft : System.Web.UI.UserControl
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //dem so cv cua ung vien chua duoc kich hoat
                int countCV = 0;               
                var kq = from n in data.CV_UngViens
                         select n;
                foreach (var s in kq)
                {
                    if (s.TrangThai == false)
                    {
                        countCV++;
                    }
                    else
                        countCV = 0;
                }
                lblDemCV.Text = countCV.ToString();

                //dem so cong viec cua cong ty chua duoc kich hoat
                int countTT = 0;
                var query = from m in data.TinViecLams
                            select m;
                foreach (var a in query)
                {
                    if (a.TrangThai == false)
                    {
                        countTT++;
                    }
                    else
                        countTT = 0;
                }
                lblDemTT.Text = countTT.ToString();
            }
        }
    }
}