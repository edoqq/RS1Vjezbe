namespace MojaApp.API.Models
{
    public class Upis
    {
        public int Id { get; set; }
        public Predmet Predmet { get; set; }
        public int PredmetId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public DateOnly DatumUpisa { get; set; }
    }
}
