using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models
{
    public class Presentation : Resource
    {
        const int Priority = 3;

        public Presentation(string name, string creator)
            : base(name, creator, Priority)
        {
        }
    }
}
