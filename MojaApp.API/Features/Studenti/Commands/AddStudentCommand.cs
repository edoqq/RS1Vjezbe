using MediatR;
using MojaApp.API.Dtos;
using System.ComponentModel.DataAnnotations;

namespace MojaApp.API.Features.Studenti.Commands
{
    public class AddStudentCommand :IRequest<StudentResponse>
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string BrojIndeksa { get; set; }

        public DateOnly? DatumRodjenja { get; set; }
    }
}
