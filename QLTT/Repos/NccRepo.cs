using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class NccRepo : IRepo<NhaCungCap>
    {
        private QuanLyNhaThuocEntities entities;
        public NccRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool Add(NhaCungCap entity)
        {
            entities.NhaCungCaps.Add(entity);
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

        private bool Update(NhaCungCap ncc)
        {
            var nccIndb = entities.NhaCungCaps.Where(n => n.MaNCC == ncc.MaNCC).SingleOrDefault();
            if (nccIndb == null) return false;
            nccIndb.TenNCC = ncc.TenNCC;
            nccIndb.DiaChiNCC = ncc.DiaChiNCC;
            nccIndb.DienThoaiNCC = ncc.DienThoaiNCC;
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

        public NhaCungCap GetOne(Expression<Func<NhaCungCap, bool>> predicate)
        {
            return entities.NhaCungCaps.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<NhaCungCap> List()
        {
            return entities.NhaCungCaps.ToList();
        }

        public IEnumerable<NhaCungCap> List(Expression<Func<NhaCungCap, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<NhaCungCap, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
