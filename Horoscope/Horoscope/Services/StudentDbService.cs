using Horoscope.Domain;
using Microsoft.EntityFrameworkCore;

namespace Horoscope.Services
{
    internal class StudentDbService : IStudentService
    {
        private HoroscopeDbContext _context;

        public StudentDbService(HoroscopeDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public Student GetStudentById(Guid id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
