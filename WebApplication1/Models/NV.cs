namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NV")]
    public partial class NV
    {
        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        public int? HSLuong { get; set; }
    }
}
