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
    public class clsViTriLamViec
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<ViTriUngTuyen> dsViTri()
        {
            var kq = from n in data.ViTriUngTuyens
                     select n;
            return kq.ToList<ViTriUngTuyen>();
        }

        //luu vi tri
        public void LuuViTri(string tenvitri)
        {
            ViTriUngTuyen vt = new ViTriUngTuyen();
            vt.TenViTri = tenvitri;
            data.ViTriUngTuyens.InsertOnSubmit(vt);
            data.SubmitChanges();
        }

        //sua vi tri
        public void SuaViTri(int id, string vitri)
        {
            var kq = data.ViTriUngTuyens.Single(p => p.ID_ViTri == id);
            kq.TenViTri = vitri;
            data.SubmitChanges();
        }

        //xoa vi tri
        public void XoaViTri(int idViTri)
        {
            var kq = (from n in data.ViTriUngTuyens
                      select n).Single(p => p.ID_ViTri == idViTri);
            data.ViTriUngTuyens.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }
    }
}
