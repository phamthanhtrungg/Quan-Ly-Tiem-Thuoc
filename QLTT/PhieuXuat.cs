//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTT
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuXuat
    {
        public int MaPhieuXuat { get; set; }
        public string MaSP { get; set; }
        public string MaNV { get; set; }
        public int GiaBan { get; set; }
        public System.DateTime NgayXuat { get; set; }
        public int SoLuongXuat { get; set; }
        public string TenSP { get; set; }
    
        public virtual KhoThuoc KhoThuoc { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
