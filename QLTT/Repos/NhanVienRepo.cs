using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QLTT.Repos
{
    public class NhanVienRepo : IRepo<NhanVien>
    {
        private readonly QuanLyNhaThuocEntities entities;
        public NhanVienRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }

        internal Task<bool> GetOneAsync()
        {
            throw new NotImplementedException();
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


        public async Task<bool> Update(Expression<Func<NhanVien, bool>> predicate, params string[] args)
        {
            var nhanVien = await entities.NhanViens.Where(predicate).SingleOrDefaultAsync();
            return false;
        }
    }
}
