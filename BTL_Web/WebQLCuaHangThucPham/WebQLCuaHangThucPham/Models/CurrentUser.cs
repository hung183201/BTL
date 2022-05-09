using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLCuaHangThucPham.Models
{
    /// <summary>
    /// Chứa thông tin của người đăng nhập
    /// </summary>
    public static class CurrentUser
    {
        public static int MaKH
        {
            get
            {
                try
                {
                    //makh|tenkh : 1|hieu
                    var strInfo = HttpContext.Current.User.Identity.Name.Split('|');
                    return Convert.ToInt32(strInfo[0]);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static string TenKH
        {
            get
            {
                try
                {
                    var strInfo = HttpContext.Current.User.Identity.Name.Split('|');
                    return strInfo[1];
                }
                catch
                {
                    return "";
                }
            }
        }
        public static string DiaChi
        {
            get
            {
                try
                {
                    var strInfo = HttpContext.Current.User.Identity.Name.Split('|');
                    return strInfo[2];
                }
                catch
                {
                    return "";
                }
            }
        }
        public static string SDT
        {
            get
            {
                try
                {
                    var strInfo = HttpContext.Current.User.Identity.Name.Split('|');
                    return strInfo[3];
                }
                catch
                {
                    return "";
                }
            }
        }
        public static string Email
        {
            get
            {
                try
                {
                    var strInfo = HttpContext.Current.User.Identity.Name.Split('|');
                    return strInfo[4];
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}