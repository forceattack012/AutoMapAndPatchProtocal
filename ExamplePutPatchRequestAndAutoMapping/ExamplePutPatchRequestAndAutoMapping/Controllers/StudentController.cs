using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamplePutPatchRequestAndAutoMapping.Models;
using ExamplePutPatchRequestAndAutoMapping.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ExamplePutPatchRequestAndAutoMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IStudentRepo _studentRepo;
        public StudentController(IStudentRepo studentRepo, IMapper mapper)
        {
            this._studentRepo = studentRepo;
            this._mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetStudentView()
        {
            ICollection<Student> student = await _studentRepo.GetStudentAsync();
            ICollection<ViewStudent> viewStudent = _mapper.Map< ICollection<Student> ,ICollection <ViewStudent>>(student);
         
            return Ok(viewStudent);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> InsertStudent([FromBody] ViewStudent viewStudent)
        {
            var studentModel = _mapper.Map<ViewStudent, Student>(viewStudent);
            await _studentRepo.AddAsync(studentModel);
            await _studentRepo.SaveAllAsync();
            var stu = _mapper.Map<Student, ViewStudent>(studentModel);
            return Ok(stu);
        }

        [HttpPut("put/{id}")]
        public async Task<IActionResult> Put(string id,[FromBody] Student student)
        {
            Student oldStudent = await _studentRepo.GetAsyncById(id);
            _mapper.Map(student, oldStudent);
            await _studentRepo.SaveAllAsync();

            return Ok(_mapper.Map<Student, ViewStudent>(student));
        }

        [HttpPatch("patch/{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<ViewStudent> student)
        {
            Student oldStudent = await _studentRepo.GetAsyncById(id);
            var stu = _mapper.Map<Student,ViewStudent>(oldStudent);

            student.ApplyTo(stu);
            _mapper.Map(stu,oldStudent);

            await _studentRepo.UpdateAsync(oldStudent);
            await _studentRepo.SaveAllAsync();

            return Ok(_mapper.Map<Student, ViewStudent>(oldStudent));
        }
    }
}