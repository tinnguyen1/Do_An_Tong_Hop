using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DS_XuatKhoDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public DS_XuatKhoDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public int ThemMoi(DS_XuatKho ma)
        {
            db.DS_XuatKho.Add(ma);
            db.SaveChanges();
            return ma.MaHangXuatKho;
        }
    }
}
