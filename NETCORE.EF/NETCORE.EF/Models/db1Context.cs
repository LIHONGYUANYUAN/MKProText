using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NETCORE.EF.Models
{
    public partial class db1Context : DbContext
    {
        public db1Context()
        {
        }

        public db1Context(DbContextOptions<db1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderItem> TblOrderItem { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=123456;port=3306;database=db1;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.ToTable("tbl_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Order_Code)
                    .HasColumnName("order_code")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Uptime)
                    .HasColumnName("uptime")
                    .HasColumnType("datetime");

                entity.Property(e => e.User_Id)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<TblOrderItem>(entity =>
            {
                entity.ToTable("tbl_order_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.GoodsId)
                    .HasColumnName("goods_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
