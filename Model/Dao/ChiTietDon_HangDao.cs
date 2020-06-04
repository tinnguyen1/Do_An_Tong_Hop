using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ChiTiet_DonHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public ChiTiet_DonHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public bool Add(ChiTietDonHang ma)
        {
            try
            {
                db.ChiTietDonHangs.Add(ma);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
