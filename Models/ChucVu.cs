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

    public partial class ChucVu
    {
        public ChucVu()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }

        [Required(ErrorMessage = "Mã chức vụ không được để trống")]
        public string maChucVu { get; set; }

        [Required(ErrorMessage = "Tên chức vụ không được để trống")]
        public string tenChucVu { get; set; }
    
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
