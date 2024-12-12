using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ReflectionRecursion
{
    public class Subject
    {
        public string Name { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int[] Gatter { get; set; }
        public List<int> Ages { get; set; }
        public List<Subject> Subjects { get; set; }
        public class Program
        {
            static void Main(string[] args)
            {
                var person = new Person();
                person.Id = 123;
                person.Name = "Jhon";
                person.Email = "jhon@edu.com";
                person.Gatter = [1, 2, 3, 4, 5];
                person.Ages = new List<int>() {1,2,3,4,5,6};
                person.Subjects = new List<Subject>()
                {
                    new Subject(){Name = "English" },
                    new Subject(){Name = "Bangla" }
                };

                Console.WriteLine(XMLFormatter.Convert(person));
            }
        }
    }
}
