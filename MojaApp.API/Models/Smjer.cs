namespace MojaApp.API.Models
{
    public class Smjer
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Student> Studenti { get; set; }
    }
}
