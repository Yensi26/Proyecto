using Domain;

namespace Backend.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Domain.Rutine> Rutines { get; set; }

        public System.Data.Entity.DbSet<Domain.Excercise> Excercises { get; set; }
    }
}