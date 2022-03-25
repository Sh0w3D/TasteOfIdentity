namespace TaseOfIdentity.Models
{
    public class StudentModel
    {
        public string Id { get; set; } // = Guid.NewGuid().ToString("D");

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime UpdatedTime { get; set; } // = DateTime.UtcNow;
    }
}
