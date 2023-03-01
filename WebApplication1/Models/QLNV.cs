using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class QLNV : DbContext
    {
        public QLNV()
            : base("name=QLNV")
        {
        }

        public virtual DbSet<NV> NV { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NV>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
