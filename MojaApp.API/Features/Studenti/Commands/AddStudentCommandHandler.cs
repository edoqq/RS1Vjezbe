using MediatR;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Models;

namespace MojaApp.API.Features.Studenti.Commands
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentResponse>
    {
        private readonly AppDbContext _db;
        public AddStudentCommandHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<StudentResponse> Handle(AddStudentCommand request, CancellationToken ct)
        {
            Student student = new Student()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                BrojIndeksa = request.BrojIndeksa,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now
            };
            _db.Add(student);
            await _db.SaveChangesAsync(ct);
            return Mapiraj(student);
        }

        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojIndeksa = s.BrojIndeksa,
                DatumRodjenja = s.DatumRodjenja
            };

        }
    }
}
