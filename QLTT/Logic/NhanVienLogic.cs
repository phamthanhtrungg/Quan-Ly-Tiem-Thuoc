﻿using QLTT.Repos;
using System;

namespace QLTT.Logic
{
    public class NhanVienLogic
    {
        private readonly NhanVienRepo repo;
        public NhanVienLogic()
        {
            repo = new NhanVienRepo();
        }

        public bool DanhNhap(string username, string hashedPassword)
        {
            return repo.GetOne(n => n.Username == username && n.Password == hashedPassword) != null;

        }

        public bool DangKi(string username, string hashedPassword, string maNV, string diachiNV, string email, string gioitinhNV, string hotenNV, string maCV
            , string ngaysinhNV
            )
        {
            //check if there's any nhanvien in database with username
            var nhanvien = repo.GetOne(n => n.Username == username);
            if (nhanvien != null)
            {
                return false;
            }
            nhanvien = new NhanVien()
            {
                MaNV = maNV,
                Username = username,
                Password = hashedPassword,
                DiaChiNV = diachiNV,
                Email = email,
                NgaySinhNV = DateTime.Parse(ngaysinhNV),
                GioiTinhNV = gioitinhNV,
                HoTenNV = hotenNV,
                MaCV = maCV

            };


            return repo.Add(nhanvien);
        }
        public bool ThayDoiThongTin(string username, string hashedPassword, string dienthoai, string diachiNV, string email, string gioitinhNV, string hotenNV, string ngaysinhNV)
        {

            return repo.Update(username, hashedPassword, dienthoai, diachiNV, email, gioitinhNV, hotenNV, ngaysinhNV);
        }

    }
}
