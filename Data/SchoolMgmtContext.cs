using JWTWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTWebApi.Data
{
    public class SchoolMgmtContext : DbContext
    {
        public SchoolMgmtContext(DbContextOptions<SchoolMgmtContext> options) : base(options)
        {
            
        }

        public DbSet<SchoolDetails> SchoolDetails { get; set; }
        public DbSet<StudentList> StudentList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolDetails>()
                .HasIndex(p => new { p.userName, p.email})
                .IsUnique();
        }

    }
}