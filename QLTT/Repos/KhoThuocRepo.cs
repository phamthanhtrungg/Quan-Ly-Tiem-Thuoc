using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QLTT.Repos
{
    public class KhoThuocRepo : IRepo<KhoThuoc>
    {
        private readonly QuanLyNhaThuocEntities entities;
        public KhoThuocRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }
        public bool AddRange(List<KhoThuoc> khoThuocs)
        {
            entities.KhoThuocs.AddRange(khoThuocs);
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
        public bool RemoveRange(List<KhoThuoc> khoThuocs)
        {
            try
            {
                foreach (var item in khoThuocs)
                {
                    var sp = entities.KhoThuocs.Where(k => k.MaSP == item.MaSP).SingleOrDefault();
                    if (sp != null)
                    {
                        entities.KhoThuocs.Remove(sp);
                    }
                }
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool Add(KhoThuoc entity)
        {
            return true;
        }

        public KhoThuoc GetOne(Expression<Func<KhoThuoc, bool>> predicate)
        {
            return entities.KhoThuocs.Where(predicate).SingleOrDefault();
        }

        public IEnumerable<KhoThuoc> List()
        {
            return entities.KhoThuocs.ToList();
        }

        public IEnumerable<KhoThuoc> List(Expression<Func<KhoThuoc, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Expression<Func<KhoThuoc, bool>> predicate)
        {
            return true;
        }
    }
}
