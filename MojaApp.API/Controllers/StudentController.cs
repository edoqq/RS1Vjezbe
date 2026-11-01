using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(AppDbContext db) : Controller
    {
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            IQueryable<Student> upit = db.Student;
            return await upit.OrderBy(x=> x.Prezime).ThenBy(x=>x.Ime).Select(x => new StudentResponse
            {
                Id = x.Id,
                ImePrezime = x.Ime + ' ' + x.Prezime,
                BrojIndeksa = x.BrojIndeksa,
                DatumRodjenja = x.DatumRodjenja,
                Smjer = x.Smjer != null ? x.Smjer.Naziv : null
            }).ToListAsync(ct);
            //var students = await db.Student.ToListAsync(ct);
            //return students.Select(Mapiraj).ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>> GetById(int id, CancellationToken ct)
        {
            Student? s = await db.Student.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (s == null)
                return NotFound();
            return Ok(Mapiraj(s));
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> AddStudent(StudentAddRequest request, CancellationToken ct)
        {
            Student student = new Student()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                BrojIndeksa = request.BrojIndeksa,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now
            };
            db.Add(student);
            await db.SaveChangesAsync(ct);
            return Ok(Mapiraj(student));
        }

        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojIndeksa=s.BrojIndeksa,
                DatumRodjenja=s.DatumRodjenja
            };

        }
    }
}
