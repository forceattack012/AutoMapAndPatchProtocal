using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplePutPatchRequestAndAutoMapping.Models
{
    public interface IStudent
    {
        string Name { set; get; }
        string LastName { set; get; }
        double Score { set; get; }
    }
}
