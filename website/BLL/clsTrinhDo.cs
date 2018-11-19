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
    public class clsTrinhDo
    {
        TimViecDBDataContext data = new TimViecDBDataContext();
        public List<TrinhDo> dsTrinhDo()
        {
            var kq = from n in data.TrinhDos
                      select n;
            return kq.ToList<TrinhDo>();
        }

        //luu trinh do
        public void LuuTrinhDo(string tentrinhdo)
        {
            TrinhDo td = new TrinhDo();
            td.TenTrinhDo = tentrinhdo;
            data.TrinhDos.InsertOnSubmit(td);
            data.SubmitChanges();
        }

        //sua trinh do
        public void SuaTrinhDo(int id, string trinhdo)
        {
            var kq = data.TrinhDos.Single(p => p.ID_TrinhDo == id);
            kq.TenTrinhDo = trinhdo;
            data.SubmitChanges();
        }

        //xoa trinh do
        public void XoaTrinhDo(int id)
        {
            var kq = (from n in data.TrinhDos
                      select n).Single(p => p.ID_TrinhDo == id);
            data.TrinhDos.DeleteOnSubmit(kq);
            data.SubmitChanges();
        }
    }
}
