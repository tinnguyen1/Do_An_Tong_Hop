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
        //public List<CT_DatPhong> ThongtintheoMaDatPhong_MaPhong(int mdp,int mp)
        //{
        //    return db.CT_DatPhong.Where(x => x.MaDatPhong == mdp && x.MaPhong == mp).ToList();
            
        //}
        public Bang_DS_DatPhong ViewDentail(int dp)
        {
            return db.Bang_DS_DatPhongs.Find(dp);
        }
        public int XacNhanDatPhong(Bang_DS_DatPhong ma)
        {
            db.Bang_DS_DatPhongs.Add(ma);
            db.SaveChanges();
            return ma.MaDatPhong;
        }
        //public bool XacNhanDatPhong(CT_DatPhong dp)
        //{
        //    try
        //    {
        //        var nhom = ViewDentail(dp.MaDatPhong);
        //        nhom.MaPhong = dp.MaPhong;
        //        nhom.Bang_DS_DatPhong.HoTen = dp.Bang_DS_DatPhong.HoTen;
        //        nhom.Bang_DS_DatPhong.NgayKT = dp.Bang_DS_DatPhong.NgayKT;
        //        nhom.Bang_DS_DatPhong.SDT = dp.Bang_DS_DatPhong.SDT;
        //        nhom.Bang_DS_DatPhong.SoNguoi = dp.Bang_DS_DatPhong.SoNguoi;
        //        nhom.Bang_DS_DatPhong.DiaChi = dp.Bang_DS_DatPhong.DiaChi;
        //        nhom.Bang_DS_DatPhong.Email = dp.Bang_DS_DatPhong.Email;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }  
        //}   

        public List<PhongKhachSan> ListAll1()
        {
            return db.PhongKhachSans.ToList();
        }

    }

}


