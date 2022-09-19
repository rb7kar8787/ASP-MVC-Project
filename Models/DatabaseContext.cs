//using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {


        }
        public DbSet<Student> Student_table { get; set; }
        public DbSet<Departments> Department_table {get;set;}



    }
}
