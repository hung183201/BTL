using System.Linq;

namespace WebQLCuaHangThucPham.Models
{
    public class GioHang
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double Gia { get; set; }
        public string AnhSP { get; set; }
        public int SL { get; set; }

        public double ThanhTien
        {
            get { return Gia * SL; }
        }

        public GioHang(int MaSP, int SL)
        {
            this.MaSP = MaSP;
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            GiaSP gia = db.GiaSPs.SingleOrDefault(n => n.MaSP == MaSP);
            var anh = db.AnhSPs.Where(x => x.MaSP == MaSP).First().URL;
            TenSP = sp.TenSP;
            AnhSP = anh;
            Gia = double.Parse(gia.Gia.ToString());
            this.SL = SL;
        }

    }
}