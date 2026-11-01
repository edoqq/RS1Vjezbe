using System.ComponentModel.DataAnnotations;

namespace MojaApp.API.Dtos
{
    public class StudentAddRequest
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
