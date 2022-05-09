using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WebQLCuaHangThucPham.Models
{

    [MetadataTypeAttribute(typeof(KhachHangMetaDaTa))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetaDaTa
        {
            public int MaKH { get; set; }
            public string HoTen { get; set; }
            public string GioiTinh { get; set; }
            public Nullable<int> Tuoi { get; set; }
            public string Email { get; set; }
            public string SDT { get; set; }
            public Nullable<System.DateTime> Time_Create { get; set; }
            public Nullable<System.DateTime> Time_Update { get; set; }
            public string NguoiTao { get; set; }
            public Nullable<byte> isActive { get; set; }
            public Nullable<byte> isDelete { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public Nullable<byte> Admin { get; set; }
            public string DiaChi { get; set; }
        }
    }
}