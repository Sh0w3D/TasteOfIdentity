using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("Student", Schema = "public")]
    public class Student
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("D");

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;



    }
}
