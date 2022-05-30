using Horoscope.Domain;
using System.Xml.Linq;

namespace Horoscope.Services
{
    public class StudentXmlService : IStudentService
    {
        private readonly string _xmlPath = "C:/Users/user/Desktop/faculta/dacss/Horoscope/Horoscope/Students.xml";

        public async Task<Student> AddStudent(Student student)
        {
            // write in xml file

            var fileStream = new FileStream(_xmlPath, FileMode.Open);
            var xml = await XDocument.LoadAsync(fileStream, LoadOptions.PreserveWhitespace, CancellationToken.None);
            fileStream.Close();

            var lastStudentId = (await GetAllStudents()).LastOrDefault().Id;

            var element = new XElement("student",
                                new XElement("id", student.Id),
                                new XElement("name", student.Name)
                         );
            xml.Element("students").Add(element);
            using (FileStream fs = new FileStream(_xmlPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                StreamReader sr = new StreamReader(fs);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.SetLength(0);
                    xml.Save(sw);
                }
                fs.Close();
            }


            throw new NotImplementedException();
        }

        public Student GetStudentById(Guid id)
        {
            // read from xml
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var fileStream = new FileStream(_xmlPath, FileMode.Open);
            var xml = await XDocument.LoadAsync(fileStream, LoadOptions.PreserveWhitespace, CancellationToken.None);
            fileStream.Close();

             var students = from c in xml.Root.Descendants("student")
                           select new Student() { Name = c.Element("name").Value, Id = Guid.Parse(c.Element("id").Value) };
            
            return students.ToList();
        }
    }
}
