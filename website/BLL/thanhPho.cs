using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using DAL;

namespace BLL
{
    public class thanhPho
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<ThanhPho> dsThanhPho()
        {
            var kq = from n in data.ThanhPhos
                     select n;
            return kq.ToList<ThanhPho>();
        }

        //luu thanh pho
        public void LuuTP(string tenTP, int vung)
        {
            ThanhPho tp = new ThanhPho();
            tp.TenThanhPho = tenTP;
            tp.ID_Vung = vung;
            data.ThanhPhos.InsertOnSubmit(tp);
            data.SubmitChanges();
        }

        //sua thanh pho
        public void SuaThanhPho(int id, string thanhpho, int idvung)
        {
            var kq = data.ThanhPhos.Single(p => p.ID_ThanhPho == id);
            kq.TenThanhPho = thanhpho;
            kq.ID_Vung = idvung;
            data.SubmitChanges();
        }

        //xoa thanh pho
        public void XoaThanhPho(int id)
        {
            var kq = (from n in data.ThanhPhos
                      select n).Single(p => p.ID_ThanhPho == id);
            data.ThanhPhos.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }
    }
}
