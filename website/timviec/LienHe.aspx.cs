using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace timviec
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void xoa()
        {
            txtLienHe_TieuDe.Text = "";
            txtLienHe_Email.Text = "";
            txtLienHe_NoiDung.Text = "";
            txtLienHe_HoTen.Text = "";
        }

        protected void btnLienHe_Huy_Click(object sender, EventArgs e)
        {
            xoa();
        }

        protected void btnLienHe_Gui_Click(object sender, EventArgs e)
        {
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential("boybuonht@gmail.com", "kienle1441990");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();

            try
            {
                mail.From = new MailAddress(txtLienHe_Email.Text, txtLienHe_HoTen.Text + " gửi từ trang liên hệ Website timvieconline", System.Text.Encoding.UTF8);
                mail.To.Add("boybuonht@gmail.com");
                mail.Subject = txtLienHe_TieuDe.Text;
                mail.Body = MailBody();
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress("boybuonht@gmail.com");
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
                xoa();
                Response.Write("<script> alert('Gửi thành công.')</script>");
            }
            catch (Exception ex) { }
        }

        private string MailBody()
        {
            string str = "";
            str += "Thông tin phản hồi từ Trang Web" + "<br/>";
            str += "Tiêu đề: " + txtLienHe_TieuDe.Text + "<br/>";
            str += "Họ tên: " + txtLienHe_HoTen.Text + "<br/>";
            str += "Email: " + txtLienHe_Email.Text + "<br/>";
            str += "Nội dung: " + txtLienHe_NoiDung.Text + "<br/>";
            return str;
        }
    }
}