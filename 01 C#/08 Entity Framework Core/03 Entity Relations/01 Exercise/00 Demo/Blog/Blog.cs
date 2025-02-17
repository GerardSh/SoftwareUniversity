using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public  DateTime LastUpdated { get; set; }
    }
}
