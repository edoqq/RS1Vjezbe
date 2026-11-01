using Microsoft.EntityFrameworkCore;
using MojaApp.API.Models;

namespace MojaApp.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Student => Set<Student>();
        public DbSet<Smjer> Smjer => Set<Smjer>();
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
            modelBuilder.Entity<Student>().HasOne(x => x.Smjer).
                WithMany(smjer => smjer.Studenti).
                HasForeignKey(x => x.SmjerId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Smjer>().HasData(
                new Smjer
                {
                    Id = 1,
                    Naziv="Softverski inzinjering",
                },
                new Smjer
                {
                    Id=2,
                    Naziv="Razvoj softvera"
                }
                );
        }
    }
}
