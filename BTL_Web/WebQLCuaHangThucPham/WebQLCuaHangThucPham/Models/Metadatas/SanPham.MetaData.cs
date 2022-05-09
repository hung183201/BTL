using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WebQLCuaHangThucPham.Models
{
    [MetadataTypeAttribute(typeof(SanPhamMetaData))]
    public partial class SanPham
    {
        internal sealed class SanPhamMetaData
        {
            [Display(Name = "Mã Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaSP { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Tên Sản Phẩm")]
            public string TenSP { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Giới thiệu ")]
            public string GTSP { get; set; }
            [Required]
            [Display(Name = "Số Lượng")]
            public Nullable<int> SL { get; set; }
            //[Required]
            //[Display(Name = "Thời Gian Tạo")]
            //public Nullable<System.DateTime> Time_Create { get; set; }
            //[Required]
            //[Display(Name = "Thời Gian Update")]
            //public Nullable<System.DateTime> Time_Update { get; set; }
        }
    }
}