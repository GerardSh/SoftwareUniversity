using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    public class Exam : Resource
    {
        public Exam(string name, string creator) 
            : base(name, creator, 1)
        {
        }
    }
}
