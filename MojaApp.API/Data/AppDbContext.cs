using Microsoft.EntityFrameworkCore;
using MojaApp.API.Models;

namespace MojaApp.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Student => Set<Student>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 1,
                Ime = "Ana",
                Prezime = "Anic",
                BrojIndeksa = "IB111111",
                DatumRodjenja = new DateOnly(1999, 03, 20),
                DatumKreiranja = new DateTime(2026, 10, 31)
            }
            ,
            new Student()
            {
                Id = 2,
                Ime = "Samir",
                Prezime = "Samiric",
                BrojIndeksa = "IB240231",
                DatumRodjenja = new DateOnly(2002, 04, 25),
                DatumKreiranja = new DateTime(2026, 10, 31)
            }
            );
        }
    }
}
