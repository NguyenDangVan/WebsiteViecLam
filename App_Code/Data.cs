using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public class Data
{
    static String Con = @"Data Source=LAPTOP-L95MANEC\SQLEXPRESS;Initial Catalog=WebsiteViecLam;Integrated Security=True";

    public DataTable GetTable(string r)
    {
        DataTable dt = new DataTable();
        SqlConnection KetNoi = new SqlConnection(Con);
        KetNoi.Open();
        SqlDataAdapter ad = new SqlDataAdapter(r, KetNoi);
        dt.Clear();
        ad.Fill(dt);
        KetNoi.Close();
        return dt;
    }
    public void NowR(string r)
    {
        SqlConnection KetNoi = new SqlConnection(Con);
        KetNoi.Open();
        SqlCommand cmd = new SqlCommand(r, KetNoi);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd.Clone();
        KetNoi.Close();
    }
    //private string Con = @"Data Source=SZWGODPRRCULCER\SQLEXPRESS;Initial Catalog=WebsiteViecLam;Integrated Security=True";
    //private SqlConnection sqlCon;
    //public Data()
    //{
    //    sqlCon = new SqlConnection();
    //    sqlCon.ConnectionString = this.Con;
    //}

    //public SqlDataReader GetDataReader(string query)
    //{
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(query, sqlCon);
    //        return cmd.ExecuteReader();
    //    }
    //    catch
    //    {
    //    }
    //    return null;
    //}
    //public int Excutequery(String query)
    //{
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand(query, sqlCon);
    //        return cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception)
    //    {
    //    }
    //    return -1;
    //}

    //public DataTable GetDataTable(String query)
    //{
    //    try
    //    {
    //        SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        return ds.Tables[0];
    //    }
    //    catch (Exception)
    //    {
    //    }
    //    return null;
    //}
}