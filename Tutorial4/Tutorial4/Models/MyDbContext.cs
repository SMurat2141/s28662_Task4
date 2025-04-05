using Microsoft.EntityFrameworkCore;
using Tutorial3.Models;  

namespace Tutorial4.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<Salgrade> Salgrades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}