using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace timviec.NguoiTimViec
{
    public partial class demo : System.Web.UI.Page
    {
        public string CurrentUser_Name { get; set; }
        public int CurrentUser_ID { get; set; }
        protected override void OnInit(EventArgs e)
        {
            if (Session.GetName_NguoiTimViec() == null)
            {
                Response.Redirect("DangNhapNguoiTimViec.aspx");
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UngVien ten = Session.GetName_NguoiTimViec();
            UngVien id = Session.GetID_NguoiTimViec();
            if (ten != null)
            {
                CurrentUser_Name = ten.HoTen;
                CurrentUser_ID = id.ID_UngVien;
                Label1.Text = "Chào:" + CurrentUser_Name;
                Label2.Text = "ID: " + CurrentUser_ID;
            }
        }
    }
}