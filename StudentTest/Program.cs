using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService();
            service.Add(new Student
            {
                Name = "Ivan",
                Age = 20,
                Lastname = "Ivanov",
            });
            service.Add(new Student
            {
                Name = "Petro",
                Age = 22,
                Lastname = "Petrenko",
            });
            Random rand = new Random();
            foreach(Student item in service.Students)
            {
                item.AddMark("C++", rand.Next(1, 12));
                item.AddMark("C#", rand.Next(1, 12));
            }
            foreach(var item in service.Students)
            {
                Console.WriteLine(item);
            }
            service.Save();
        }
    }
}
