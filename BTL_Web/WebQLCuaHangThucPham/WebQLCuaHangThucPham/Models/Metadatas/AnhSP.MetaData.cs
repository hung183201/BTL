using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WebQLCuaHangThucPham.Models
{

    [MetadataTypeAttribute(typeof(AnhSPMetaData))]
    public partial class AnhSP
    {
        internal sealed class AnhSPMetaData
        {
            [Display(Name = "Mã Ảnh")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaAnh { get; set; }
            [Display(Name = "Mã Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaSP { get; set; }
            [Display(Name = "Tên Ảnh")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenAnh { get; set; }
            [Display(Name = "URL")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string URL { get; set; }

        }
    }
}