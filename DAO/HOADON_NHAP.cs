//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON_NHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON_NHAP()
        {
            this.CTHD_NHAP = new HashSet<CTHD_NHAP>();
        }
    
        public int MaHD { get; set; }
        public System.DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int MaNCC { get; set; }
        public double ThanhTien { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD_NHAP> CTHD_NHAP { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
