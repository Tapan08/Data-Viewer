using StudentsApp.Entities;

namespace StudentsApp.Models
{
    public class StudentsViewModel
    {
        public List<Student> Students = new List<Student>();

        public string[] TabNames = new string[] {"All", "Full-time", "Part-time", "Graduate", "Continuing-Ed" };

        public string[] stat = new string[] { "Full-time", "Part-time", "Graduate", "Continuing-Ed" };
        public string Active { get; set; }
        public Student New { get; set; }
    }
}
