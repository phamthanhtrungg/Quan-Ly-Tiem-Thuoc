using System.Collections.Generic;
using System.Linq;

namespace QLTT.Repos
{
    public class ChucVuRepo
    {
        private readonly QuanLyNhaThuocEntities entities;
        public ChucVuRepo()
        {
            entities = new QuanLyNhaThuocEntities();
        }

        public IEnumerable<ChucVu> GetAll()
        {
            return entities.ChucVus.ToList();
        }
    }
}
