using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATM_Management_CoreRestApi.Data.Model
{
    public partial class AtmManagmentContext : DbContext
    {
        public virtual DbSet<Terminal> Terminal { get; set; }

        public AtmManagmentContext(DbContextOptions opts) : base(opts)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
              //  optionsBuilder.UseNpgsql(@"User ID = postgres;Password=1;Server=localhost;Port=5432;Database=atm;Integrated Security=true; Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.ToTable("terminal", "atm_mng");

                entity.Property(e => e.TerminalId).HasDefaultValueSql("1");

                entity.Property(e => e.Desc).HasColumnType("varchar");

                entity.Property(e => e.TerminalCode).HasColumnType("varchar");
            });
        }
    }
}
