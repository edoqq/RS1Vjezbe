using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Features.Studenti.Commands;
using MojaApp.API.Features.Studenti.Queries.GetAllStudenti;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(ISender sender) : Controller
    {
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            return await sender.Send(new GetAllStudentiQuery(), ct);
            //var students = await db.Student.ToListAsync(ct);
            //return students.Select(Mapiraj).ToList();
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<StudentDetailsResponse>> GetById(int id, CancellationToken ct)
        //{
        //    StudentDetailsResponse s = await db.Student.Where(x => x.Id == id).Select(x => new StudentDetailsResponse
        //    {
        //        Id = x.Id,
        //        ImePrezime = x.Ime + " " + x.Prezime,
        //        BrojIndeksa = x.BrojIndeksa,
        //        DatumRodjenja = x.DatumRodjenja,
        //        Smjer = x.Smjer != null ? x.Smjer.Naziv : null,
        //        Upisi = x.Upisi.Select(u => new StudentUpisResponse
        //        {
        //            UpisId = u.Id,
        //            Predmet = u.Predmet.Naziv,
        //            Sifra = u.Predmet.Sifra,
        //            DatumUpisa = u.DatumUpisa
        //        }).ToList()
        //    }).FirstAsync(ct);
        //    return Ok(s);
        //}

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> AddStudent(AddStudentCommand request, CancellationToken ct)
        {
            return await sender.Send(request, ct);
        }
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<Student>> Update(int id, StudentUpdateRequest request,CancellationToken ct)
        //{
        //    Student? student = await db.Student.FirstOrDefaultAsync(x => x.Id == id, ct);
        //    if (student == null)
        //        return NotFound();
        //    student.Ime = request.Ime;
        //    student.Prezime = request.Prezime;
        //    student.BrojIndeksa = request.BrojIndeksa;
        //    student.DatumRodjenja = request.DatumRodjenja;
        //    student.SmjerId = request?.SmjerId;
        //    await db.SaveChangesAsync(ct);
        //    return Ok(Mapiraj(student));
        //}
        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id, CancellationToken ct)
        //{
        //    var student = await db.Student.FirstOrDefaultAsync(x => x.Id == id, ct);
        //    if (student == null) return NotFound();
        //    db.Student.Remove(student);
        //    await db.SaveChangesAsync(ct);
        //    return NoContent();
        //}
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
