using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Mark> Marks { get; set; }
        public Student()
        {
            Marks = new List<Mark>();
        }
        public override string ToString()
        {
            string rating = String.Empty;
            foreach (var item in Marks)
            {
                rating += Environment.NewLine + item;
            }
            return $"{Name} {Lastname}, {Age}, {rating}";
        }
        public void AddMark(string subject, int value)
        {
            Marks.Add(new Mark
            {
                Subject = subject,
                Rating = value
            });
        }
    }
    [Serializable]

    public class Mark
    {
        public int Rating { get; set; }
        public string Subject { get; set; }
        public override string ToString()
        {
            return $"Subject:{Subject}, Rating: {Rating}";
        }
    }
}
