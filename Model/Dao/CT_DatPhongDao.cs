using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class CT_DatPhongDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public CT_DatPhongDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public bool Add(CT_DatPhong ma)
        {
            try
            {
                db.CT_DatPhong.Add(ma);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public List<PhongKhachSan> ListAll1()
        {
            return db.PhongKhachSans.ToList();
        }

    }

}


