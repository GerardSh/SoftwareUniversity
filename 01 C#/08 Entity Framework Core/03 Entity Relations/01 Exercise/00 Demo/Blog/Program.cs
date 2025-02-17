using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo
{
    public class Program
    {
        public static void Main()
        {
            Blog blog = new Blog();

            blog.Name = null;

            Console.WriteLine(blog.Name);
        }
    }
}
