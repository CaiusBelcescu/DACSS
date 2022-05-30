using Horoscope.Domain;

namespace Horoscope.Services
{
    public interface IStudentService
    {
        Task<Student> AddStudent(Student student);

        Student GetStudentById(Guid id);

        Task<List<Student>> GetAllStudents();
    }
}
