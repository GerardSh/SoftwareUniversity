using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    public class Workshop : Resource
    {
        const int Priority = 2;

        public Workshop(string name, string creator)
            : base(name, creator, Priority)
        {
        }
    }
}
