using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for UngVienBLL
/// </summary>
public class UngVienBLL
{
    Data data = new Data();
    public bool KiemTraEmail(string email)
    {
        string kq = "SELECT * FROM UngVien";
        string dt = data.GetTable(kq).Rows[0][0].ToString();
        DataTable mytable = new DataTable();
        mytable = data.GetTable(kq);
        foreach (DataRow row in mytable.Rows)
        {
            if (row["Email"] == email)
                return false;
            else
                return true;
        }
        return true;
    }
	public UngVienBLL()
	{

	}
}