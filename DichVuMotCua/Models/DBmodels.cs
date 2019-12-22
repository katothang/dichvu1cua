namespace DichVuMotCua.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBmodels : DbContext
    {
        public DBmodels()
            : base("name=DBmodels")
        {
        }

        public virtual DbSet<chitiethoso> chitiethosoes { get; set; }
        public virtual DbSet<chitietthutuc> chitietthutucs { get; set; }
        public virtual DbSet<hoso> hosoes { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<thutuc> thutucs { get; set; }

        public virtual DbSet<loaithutuc> loaithutucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
