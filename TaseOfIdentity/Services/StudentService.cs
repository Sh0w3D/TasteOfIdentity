using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TaseOfIdentity.Models;

namespace TaseOfIdentity.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext dbContext;

        public StudentService(ApplicationDbContext dbContext) => this.dbContext = dbContext;

        public async Task<List<StudentModel>> List()
        {
            var Student = await (from student in dbContext.Student select new StudentModel()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                UpdatedTime = student.UpdatedTime,
            }).ToListAsync();

            return Student;
        }

    }
}
