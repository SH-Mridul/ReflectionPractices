using System.Reflection.Metadata;
using System.Reflection;

namespace ReflectionAttributes
{
    public class AnyInfo:Attribute
    {
        public string Info { get; }
        public AnyInfo(string info)
        {
            Info = info;
        }
    }


    [AnyInfo("class of a person")]
    public class Person
    {
        [AnyInfo("Person Age")]
        public int Age { get; set; }

        [AnyInfo("Person Name")]
        public string Name { get; set; }
    }




    public class Program
    {
        static void Main(string[] args)
        {


            // Get type of the class
            Type type = typeof(Person);
            var classAttriutes = type.GetCustomAttributes(typeof(AnyInfo), false);
            foreach (AnyInfo attr in classAttriutes)
            {
                Console.WriteLine(attr.Info);
            }

            // Get Properties
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                Console.WriteLine($"Name of Properties:{property.Name}");
                var attriutes = property.GetCustomAttributes(typeof(AnyInfo));
                foreach (AnyInfo attriute in attriutes)
                {
                    Console.WriteLine(attriute.Info);
                }
            }
        }
    }
}
