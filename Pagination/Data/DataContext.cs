using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination
{
    public class DataContext
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i <= 100; i++)
            {
                students.Add(new Student()
                {
                    Id = i,
                    Name = $"Student-{i}"
                });
            }

            return students;
        }
    }
}
