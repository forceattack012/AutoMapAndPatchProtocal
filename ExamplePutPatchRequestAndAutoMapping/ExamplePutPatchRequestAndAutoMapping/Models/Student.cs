﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Models
{
    public class Student : IStudent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Score { get; set; }
    }
}
