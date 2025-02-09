using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> Context) : base(Context)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var building = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = building.Build();
            var conString = configuration.GetConnectionString("MyConnection");
            optionsBuilder.UseSqlServer(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> Registrations { get; set; }
        public DbSet<Room> Rooms { get; set; }


    }
}
