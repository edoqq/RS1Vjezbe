namespace MojaApp.API.Dtos
{
    public class StudentDetailsResponse
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
        public string? Smjer { get; set; }
        public List<StudentUpisResponse> Upisi { get; set; }
    }
    public class StudentUpisResponse
    {
        public int UpisId { get; set; }
        public string Predmet { get; set; }
        public string Sifra { get; set; }
        public DateOnly DatumUpisa { get; set; }
    }
}
