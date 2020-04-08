using ExamplePutPatchRequestAndAutoMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Repository
{
    public interface IStudentRepo
    {
        Task<ICollection<Student>> GetStudentAsync();
        Task UpdateAsync(Student student);
        Task<Student> GetAsyncById(string id);
        Task SaveAllAsync();
        Task AddAsync(Student student);
    }
}
