using ExamplePutPatchRequestAndAutoMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Repository
{
    public class StudentRepo : IStudentRepo
    {
        readonly List<Student> _student;
        private int _id = 1;
        public StudentRepo()
        {
            _student = new List<Student>()
            {
                new Student()
                {
                    Id = "1",
                    Name = "MiKa",
                    LastName = "AY",
                    Score = 50.0
                }
            };
        }
        public Task AddAsync(Student student)
        {
            _id += 1;
            student.Id = _id.ToString();
            _student.Add(student);
            return Task.CompletedTask;
        }

        public Task<Student> GetAsyncById(string id)
        {
            return Task.FromResult<Student>(_student.Single(r => r.Id == id));
        }

        public Task<ICollection<Student>> GetStudentAsync()
        {
            return Task.FromResult<ICollection<Student>>(_student);
        }

        public Task SaveAllAsync()
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Student student)
        {
            var stu = _student.Where(r => r.Id == student.Id).FirstOrDefault();
            stu = student;
            return Task.CompletedTask;
        }
    }
}
