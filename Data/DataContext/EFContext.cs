using Models;
using System.Data.Entity;

namespace Data.DataContext
{
    public class EFContext : DbContext, IDataContext
    {
        public EFContext(string connectionString) : base(connectionString) { }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Friends> Friends { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
