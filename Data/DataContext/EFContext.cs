using Models;
using System.Data.Entity;

namespace Data.DataContext
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Connection") { }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Friends> Friends { get; set; }
    }
}
