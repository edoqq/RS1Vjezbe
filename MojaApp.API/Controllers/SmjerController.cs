using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojaApp.API.Data;
using MojaApp.API.Dtos;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmjerController(AppDbContext db) : Controller
    {
        [HttpGet]
        public async Task<List<SmjerResponse>> GetAll(CancellationToken ct)
        {
            IQueryable<Smjer> smjerovi = db.Smjer;
            return await smjerovi.OrderBy(x => x.Naziv).Select(x => new SmjerResponse
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).ToListAsync(ct);
        }
       
    }
}
