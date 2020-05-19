using QLTT.Repos;

namespace QLTT.Logic
{
    public class NhanVienLogic
    {
        private readonly NhanVienRepo repo;
        public NhanVienLogic()
        {
            repo = new NhanVienRepo();
        }

        public bool Login(string username, string hashedPassword)
        {
            return repo.GetOne(n => n.Username == username && n.Password == hashedPassword) != null;

        }

        public bool Register(string username, string hashedPassword)
        {
            var maNV = Utils.RandomString();
            do
            {
                maNV = Utils.RandomString();
            } while (repo.GetOne(n => n.MaNV == maNV) != null);
            var nhanvien = new NhanVien()
            {
                MaNV = maNV,
                Username = username,
                Password = hashedPassword,

            };
            return repo.Add(nhanvien);
        }
    }
}
