using MojaApp.API.Models;

namespace MojaApp.API.Data
{
    public class StudentStorage
    {
        private readonly List<Student> _students = [];
        private int _nextId = 1;

        public StudentStorage()
        {
            Add(new Student()
            {
                Ime = "Edhem",
                Prezime = "Krivdic",
                BrojIndeksa = "IB240101",
                DatumRodjenja = new DateOnly(2005, 3, 15)
            });
            Add(new Student()
            {
                Ime = "Student",
                Prezime = "Studentovic",
                BrojIndeksa = "IB240001",
                DatumRodjenja = new DateOnly(2005, 10, 28)
            });
        }

        public Student Add(Student student)
        {
            student.Id = _nextId++;
            student.DatumKreiranja = DateTime.UtcNow;
            _students.Add(student);
            return student;
        }
        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
