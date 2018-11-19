using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class Connect
{
    private string Con = "Data Source=KIENLE\\KIENLE;Initial Catalog=DACN;Integrated Security=True";
    private SqlConnection sqlCon;
    public Connect()
    {
        sqlCon = new SqlConnection();
        sqlCon.ConnectionString = this.Con;
    }

    public bool OpenCon()
    {
        bool connect = false;
        if (this.sqlCon.State == ConnectionState.Closed)
        {
            sqlCon.Open();
            return true;
        }
        return connect;
    }

    public void CloseCon()
    {
        this.sqlCon.Close();
    }

    public SqlDataReader GetDataReader(string query)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            return cmd.ExecuteReader();
        }
        catch
        {
        }
        return null;
    }
    public int Excutequery(String query)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
        }
        return -1;
    }

    public DataTable GetDataTable(String query)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        catch (Exception)
        {
        }
        return null;
    }
}

