using Microsoft.EntityFrameworkCore;
using VelvetechTZ.Domain.Group;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.DAL.Repository
{
    public class DockerDbContext: DbContext
    {
        public DbSet<GroupModel>? groups { get; set; }
        public DbSet<StudentModel>? students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,5434;Database=velvetech;User Id=sa;Password=Qwerty@18;");
        }
    }
}
