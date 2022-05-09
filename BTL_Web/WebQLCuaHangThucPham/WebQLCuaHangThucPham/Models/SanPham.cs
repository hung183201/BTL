//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQLCuaHangThucPham.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.AnhSPs = new HashSet<AnhSP>();
            this.CTDHs = new HashSet<CTDH>();
            this.GiaSPs = new HashSet<GiaSP>();
        }
    
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string GTSP { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public Nullable<int> SL { get; set; }
        public Nullable<System.DateTime> Time_Create { get; set; }
        public Nullable<System.DateTime> Time_Update { get; set; }
        public string NguoiTao { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Nullable<byte> isDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhSP> AnhSPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaSP> GiaSPs { get; set; }
        public virtual LoaiSP LoaiSP { get; set; }
        public double Gia { get; set; }
    }
}
