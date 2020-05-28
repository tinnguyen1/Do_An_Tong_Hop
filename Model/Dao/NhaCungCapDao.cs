using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NhaCungCapDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public NhaCungCapDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public NhaCungCap viewDental(int ma)
        {
            return db.NhaCungCaps.Find(ma);
        }

        public List<NhaCungCap> ListAll()
        {
            return db.NhaCungCaps.ToList();
        }
    }
}
