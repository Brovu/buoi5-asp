﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase_Nhom2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NhanVien
    {

        public int maNhanVien { get; set; }

        [Required(ErrorMessage="Tên nhân viên không được để trống")]
        public string tenNhanVien { get; set; }
        public Nullable<System.DateTime> ngaySinh { get; set; }

        [Range(1000, 15000, ErrorMessage ="Lương phải từ 1000 đến 15000")]
        public Nullable<decimal> luong { get; set; }
        public string hinhAnh { get; set; }

        public Nullable<int> maPhong { get; set; }
    
        public virtual PhongBan PhongBan { get; set; }
    }
}
