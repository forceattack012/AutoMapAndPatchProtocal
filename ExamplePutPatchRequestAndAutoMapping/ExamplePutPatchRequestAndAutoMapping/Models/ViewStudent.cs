using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Models
{
    public class ViewStudent : IStudent
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Score { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
