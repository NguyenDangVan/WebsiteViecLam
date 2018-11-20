using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Web;

/// <summary>
/// Summary description for SessionExt
/// </summary>
namespace webtimviec
{
    public static class SessionExt
    {
        public static void SetCurrent_NguoiTimViec(this HttpSessionState session, string tenungvien, string maungvien)
        {
            session["TenUngVien"] = tenungvien;
            session["MaUngVien"] = maungvien;
        }
    }
}