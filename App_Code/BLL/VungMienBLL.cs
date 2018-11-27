using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for VungMienBLL
/// </summary>
public class VungMienBLL
{
    Data data = new Data();
    public void LuuVung(string tenvung)
    {
        string sql = "INSERT INTO VungMien(TenVung) VALUES (N'" + tenvung + "')";
        data.NowR(sql);
    }
    public void SuaVung(int idvung, string tenvung)
    {
        string sql = "Update VungMien Set TenVung = N'" + tenvung + "' Where ID_Vung = '" + idvung + "'";
        data.NowR(sql);
    }
    public void XoaVung(int idvung)
    {
        string sql = "Delete from VungMien where ID_Vung = '" + idvung + "'";
        data.NowR(sql);
    }
    public VungMienDTO Get_VungMien(int idvung)
    {
        VungMienDTO vm = new VungMienDTO();
        try
        {
            string kq = "Select * From VungMien Where ID_Vung = '" + idvung + "'";
            vm.TenVungMien = data.GetTable(kq).Rows[0]["TenVung"].ToString();
            vm.ID_VungMien = Convert.ToInt32(data.GetTable(kq).Rows[0]["ID_Vung"]);
            return vm;
        }
        catch
        {
            return vm;
        }
    }
    public DataTable DsVungMien()
    {
        string rowquery = "Select * from VungMien";
        DataTable dt = new DataTable();
        dt = data.GetTable(rowquery);
        return dt;
    }
    public VungMienBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}