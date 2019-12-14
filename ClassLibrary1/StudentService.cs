using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary1
{
    public class StudentService
    {
        private string path = "students.db";
        public IEnumerable<Student> Students { get; set; }
        public StudentService()
        {
            if (File.Exists(path))
                Load();
            else
            Students = new List<Student>();
        }
        private void Load()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Students = (List<Student>) bf.Deserialize(fs);
            }
        }
        public void Add(Student st)
        {
            (Students as List<Student>).Add(st);
        }
        public void Remove(string lastname)
        {
            List<Student> temp = Students as List<Student>;
            temp.Remove(temp.Find(st => st.Lastname.Equals(lastname)));
        }
        public void Save()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Students);
            }
        }
    }
}
