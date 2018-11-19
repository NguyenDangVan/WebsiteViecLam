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
    public class VungMienBLL
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<VungMien> dsVung()
        {
            var kq = from n in data.VungMiens
                     select n;
            return kq.ToList<VungMien>();
        }

        //luu vung mien
        public void LuuVung(string tenvung)
        {
            VungMien vm = new VungMien();
            vm.TenVung = tenvung;
            data.VungMiens.InsertOnSubmit(vm);
            data.SubmitChanges();
        }

        //sua vung
        public void SuaVung(int id, string vung)
        {
            var kq = data.VungMiens.Single(p => p.ID_Vung == id);
            kq.TenVung = vung;
            data.SubmitChanges();
        }

        //xoa vung
        public void XoaVung(int id)
        {
            var kq = (from n in data.VungMiens
                      select n).Single(p => p.ID_Vung == id);
            data.VungMiens.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }
    }
}
