using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class NhanVienRepo : IRepo<NhanVien>
    {
        private readonly QuanLyNhaThuocEntities entities;
        public NhanVienRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }

        public bool Add(NhanVien entity)
        {
            entities.NhanViens.Add(entity);
            try
            {
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public NhanVien GetOne(Expression<Func<NhanVien, bool>> predicate)
        {
            return entities.NhanViens.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<NhanVien> List()
        {
            return entities.NhanViens.ToList();
        }

        public IEnumerable<NhanVien> List(Expression<Func<NhanVien, bool>> predicate)
        {
            return entities.NhanViens.Where(predicate);
        }

        public bool Remove(Expression<Func<NhanVien, bool>> predicate)
        {
            var nhanVien = entities.NhanViens.Where(predicate).SingleOrDefault();
            if (nhanVien != null)
            {
                entities.NhanViens.Remove(nhanVien);
                try
                {
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool Update(string username, string hashedPassword, string dienthoai, string diachiNV, string email, string gioitinhNV, string hotenNV, string ngaysinhNV)
        {
            var nhanVien = entities.NhanViens.Where(n => n.Username == username).SingleOrDefault();
            if (nhanVien == null) return false;
            nhanVien.Password = hashedPassword;
            nhanVien.DiaChiNV = diachiNV;
            nhanVien.Email = email;
            nhanVien.GioiTinhNV = gioitinhNV;
            nhanVien.HoTenNV = hotenNV;
            nhanVien.DienThoaiNV = int.Parse(dienthoai);
            nhanVien.NgaySinhNV = DateTime.Parse(ngaysinhNV);
            try
            {
                entities.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
