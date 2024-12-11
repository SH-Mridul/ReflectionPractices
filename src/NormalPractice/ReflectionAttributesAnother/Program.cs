using System.Reflection;
using System.Runtime.CompilerServices;

namespace ReflectionAttributesAnother
{
    public class AnyInfo : Attribute
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

        public string Email { get; set; }
    }

    [AnyInfo("class of a teacher")]
    public class Teacher
    {

    }




    public class Program
    {
        static void Main(string[] args)
        {

            // getting all class which is using AnyInfo Property 
            var applied = from t in Assembly.GetExecutingAssembly().GetTypes()
                          where t.GetCustomAttributes(false)
                          .Any(a => a is AnyInfo)
                          select t;

            foreach (Type t in applied)
            {
                Console.WriteLine(t.Name);
            }


            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] allTypes = assembly.GetTypes();

            foreach (Type type in allTypes)
            {
                if (type.IsDefined(typeof(CompilerGeneratedAttribute), false)) { continue; }

                Console.WriteLine($"-----------------{type.Name}------------------");
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if(property.IsDefined(typeof(CompilerGeneratedAttribute),false) || property.Name == "TypeId") { continue; }  
                    Object[] attributes = property.GetCustomAttributes(false);

                    //getting all property which is not using any properties
                    if (attributes.Length <= 0)
                    {
                        Console.WriteLine($"Property Name:{property.Name}");
                    }

                    //getting all property which is using attribute
                    foreach (Attribute attribute in attributes)
                    {
                        Console.WriteLine($"Property Name:{property.Name}||attribute:{attribute.GetType().Name}");
                    }
                }
                Console.WriteLine("----------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
