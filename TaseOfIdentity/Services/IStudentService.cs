using TaseOfIdentity.Models;

namespace TaseOfIdentity.Services
{
    public interface IStudentService
    {
        Task<List<StudentModel>> List();
    }
}
