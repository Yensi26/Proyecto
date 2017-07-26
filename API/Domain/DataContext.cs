using System.Data.Entity;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Domain.Rutine> Rutines { get; set; }

        public System.Data.Entity.DbSet<Domain.Excercise> Excercises { get; set; }
    }
}
