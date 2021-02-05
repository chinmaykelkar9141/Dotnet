using Microsoft.EntityFrameworkCore;

namespace postman_demo.Models
{
    public partial class RetailBusinessManagementContext : DbContext
    {
        public RetailBusinessManagementContext()
        {
        }

        public RetailBusinessManagementContext(DbContextOptions<RetailBusinessManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RetailBusinessManagementSystem;User ID=sa;Password=R@j@shree@1968;persist security info=True;Connection Timeout=300;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(x => x.Cid)
                    .HasName("PK__customer__D837D05FB691085B");

                entity.ToTable("customers");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasViewColumnName("cid")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastVisitDate)
                    .HasColumnName("last_visit_date")
                    .HasViewColumnName("last_visit_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(15);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone#")
                    .HasViewColumnName("telephone#")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VisitsMade)
                    .HasColumnName("visits_made")
                    .HasViewColumnName("visits_made");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(x => x.Eid)
                    .HasName("PK__employee__D9509F6D92E2AC5C");

                entity.ToTable("employees");

                entity.Property(e => e.Eid)
                    .HasColumnName("eid")
                    .HasViewColumnName("eid")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasViewColumnName("email")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(15);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone#")
                    .HasViewColumnName("telephone#")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(x => x.Pid)
                    .HasName("PK__products__DD37D91A622E3DA4");

                entity.ToTable("products");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasViewColumnName("pid")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscntRate)
                    .HasColumnName("discnt_rate")
                    .HasViewColumnName("discnt_rate")
                    .HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name")
                    .HasMaxLength(15);

                entity.Property(e => e.OriginalPrice)
                    .HasColumnName("original_price")
                    .HasViewColumnName("original_price")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Qoh)
                    .HasColumnName("qoh")
                    .HasViewColumnName("qoh");

                entity.Property(e => e.QohThreshold)
                    .HasColumnName("qoh_threshold")
                    .HasViewColumnName("qoh_threshold");
            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.HasKey(x => x.Pur)
                    .HasName("PK__purchase__472539A87AC2F3C7");

                entity.ToTable("purchases");

                entity.Property(e => e.Pur)
                    .HasColumnName("pur#")
                    .HasViewColumnName("pur#")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .HasViewColumnName("cid")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Eid)
                    .HasColumnName("eid")
                    .HasViewColumnName("eid")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasViewColumnName("pid")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ptime)
                    .HasColumnName("ptime")
                    .HasViewColumnName("ptime")
                    .HasColumnType("date");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasViewColumnName("qty");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasViewColumnName("total_price")
                    .HasColumnType("decimal(7, 2)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(x => x.Cid)
                    .HasConstraintName("FK__purchases__cid__2E1BDC42");

                entity.HasOne(d => d.E)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(x => x.Eid)
                    .HasConstraintName("FK__purchases__eid__2C3393D0");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(x => x.Pid)
                    .HasConstraintName("FK__purchases__pid__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
