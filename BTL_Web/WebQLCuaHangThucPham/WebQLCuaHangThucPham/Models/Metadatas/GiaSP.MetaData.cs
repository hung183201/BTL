using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;


namespace WebQLCuaHangThucPham.Models
{
    [MetadataTypeAttribute(typeof(GiaSPMetaData))]
    public partial class GiaSP
    {
        internal sealed class GiaSPMetaData
        {
            [Display(Name = "Mã Giá Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaGia { get; set; }
            [Display(Name = "Giá Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<decimal> Gia { get; set; }
            [Display(Name = "Thời Gian Bắt Đầu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<System.DateTime> Time_Begin { get; set; }
            public Nullable<System.DateTime> Time_End { get; set; }
        }
    }
}