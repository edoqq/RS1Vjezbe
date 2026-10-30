using Microsoft.AspNetCore.Mvc;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(StudentStorage ss) : Controller
    {
        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            var students = ss.GetAll();
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
