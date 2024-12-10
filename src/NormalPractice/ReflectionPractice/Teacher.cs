using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPractice
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Mridul";
        public List<Course> Courses { get; set; }
    }
}
