using MediatR;
using Microsoft.EntityFrameworkCore;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Models;

namespace MojaApp.API.Features.Studenti.Queries.GetAllStudenti
{
    public class GetAllStudentiQueryHandler : IRequestHandler<GetAllStudentiQuery, List<StudentResponse>>
    {
        private readonly AppDbContext _db;
        public GetAllStudentiQueryHandler(AppDbContext db)
        {
            _db=db;
        }
        public async Task<List<StudentResponse>> Handle(GetAllStudentiQuery request, CancellationToken ct)
        {
            IQueryable<Student> upit = _db.Student.AsNoTracking();
            return await upit.OrderBy(x => x.Prezime).ThenBy(x => x.Ime).Select(x => new StudentResponse
            {
                Id = x.Id,
                ImePrezime = x.Ime + ' ' + x.Prezime, //koristimo iqueryable da se ubrza dohvatanje studenata,to jeste da se ne dohvataju smjerovi studenta i da se sve to ucitava detaljno, ovako se translatuje u sql left join
                BrojIndeksa = x.BrojIndeksa,
                DatumRodjenja = x.DatumRodjenja,
                Smjer = x.Smjer != null ? x.Smjer.Naziv : null
            }).ToListAsync(ct);
        }
    }
}
