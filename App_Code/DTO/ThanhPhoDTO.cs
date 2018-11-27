using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThanhPho
/// </summary>
public class ThanhPhoDTO
{
	public ThanhPhoDTO()
	{
		
	}
    public int ID_ThanhPho { get; set; }
    public string TenThanhPho { get; set; }
    public int ID_VungMien { get; set; }
}