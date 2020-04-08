using AutoMapper;
using ExamplePutPatchRequestAndAutoMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Mapper
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, ViewStudent>();
            CreateMap<ViewStudent, Student>();
        }
    }
}
