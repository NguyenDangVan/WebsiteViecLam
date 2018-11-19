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
    public class clsKinhNghiem
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<KinhNghiem> dsKinhNghiem()
        {
            var kq = from n in data.KinhNghiems
                     select n;
            return kq.ToList<KinhNghiem>();
        }

        //luu kinh nghiem
        public void LuuKinhNghiem(string kinhnghiem)
        {
            KinhNghiem kn = new KinhNghiem();
            kn.TenKinhNghiem = kinhnghiem;
            data.KinhNghiems.InsertOnSubmit(kn);
            data.SubmitChanges();
        }

        //xoa kinh nghiem
        public void XoaKinhNghiem(int idKinhNghiem)
        {
            var kq = (from n in data.KinhNghiems
                      select n).Single(p => p.ID_KinhNghiem == idKinhNghiem);
            data.KinhNghiems.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }

        //sua kinh nghiem
        public void SuaKinhNghiem(int id, string kinhnghiem)
        {
            var kq = data.KinhNghiems.Single(p => p.ID_KinhNghiem == id);
            kq.TenKinhNghiem = kinhnghiem;
            data.SubmitChanges();
        }
    }
}
