using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        DatabaseContext context = new DatabaseContext();
        context.Database.EnsureCreated();
        //context.Students.Add(new Student { Name = "John", Age = 20 });
        //context.SaveChanges();
        IQueryable<Student> students = from s in context.Students
                                       where s.Etcs > 20

                                       select s;
        foreach (Student s in students)
        {
            Console.WriteLine(s);
        }
    }

    public record Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Etcs { get; set; }
    }
    public class DatabaseContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        // onconfigure
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source=Database");
        }
        // onmodelcreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("students");
        }
    }
}