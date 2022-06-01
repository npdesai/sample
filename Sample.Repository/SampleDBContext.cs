using Microsoft.EntityFrameworkCore;
using Sample.Models.Entities;

namespace Sample.Repository
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext() { }

        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-SFGK9O8E;Initial Catalog=Test_Sample;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
