// See https://aka.ms/new-console-template for more information
using Horoscope;
using Horoscope.Domain;
using Horoscope.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddDbContext<HoroscopeDbContext>();

var useDatabase = false;

if (useDatabase)
{
    serviceCollection.AddSingleton<IStudentService, StudentDbService>();
}
else
{
    serviceCollection.AddSingleton<IStudentService, StudentXmlService>();
}

var serviceProvider = serviceCollection.BuildServiceProvider();

var studentRepo = serviceProvider.GetService<IStudentService>();

var student1 = new Student
{
    Name = "Ana Maria Ducu"
};

//await studentRepo.AddStudent(student1);

var allStudents = await studentRepo.GetAllStudents();

foreach(var student in allStudents)
{
    Console.WriteLine("Student: " + student.Name + " has a good day? " + student.HasAGoodDay());
}


