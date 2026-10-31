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
            var students = await db.Student.ToListAsync(ct);
            return students.Select(Mapiraj).ToList();
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
