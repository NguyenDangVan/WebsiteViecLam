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
    public class nganhNghe
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<NganhNghe> dsNganhNghe()
        {
            var kq = from n in data.NganhNghes
                     select n;
            //kq = kq.OrderBy(p => p.TenNganhNghe);
            return kq.ToList<NganhNghe>();
        }
        //Lưu ngành nghề
        public void LuuNganh(string tennganh)
        {
            NganhNghe nn = new NganhNghe();
            nn.TenNganhNghe = tennganh;
            data.NganhNghes.InsertOnSubmit(nn);
            data.SubmitChanges();
        }

        //sua nganh nghe
        public void SuaNganhNghe(int id, string tennganh)
        {
            var kq = data.NganhNghes.Single(p => p.ID_NganhNghe == id);
            kq.TenNganhNghe = tennganh;
            data.SubmitChanges();
        }

        //xoa nganh
        public void XoaNganh(int id)
        {
            var kq = (from n in data.NganhNghes
                      select n).Single(p => p.ID_NganhNghe == id);
            data.NganhNghes.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }
    }
}
