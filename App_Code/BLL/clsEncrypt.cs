﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

/// <summary>
/// Summary description for clsEncrypt
/// </summary>
public class clsEncrypt
{
    public String GetMD5(String text)
    {
        String str = "";
        Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        buffer = md5.ComputeHash(buffer);
        foreach (Byte b in buffer)
        {
            str += b.ToString("X2");
        }
        return str;
    }
	public clsEncrypt()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}