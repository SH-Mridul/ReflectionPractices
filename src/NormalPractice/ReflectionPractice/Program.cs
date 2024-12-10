using System.Reflection;
using System.Runtime.CompilerServices;

namespace ReflectionPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); //get dll
            var types = assembly.GetTypes(); //get all types
            foreach (var type in types)
            {
                if (type.IsDefined(typeof(CompilerGeneratedAttribute), false)) //reduce compiler data
                {
                    continue;
                }

                if (type.Name != "Program")
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(type.Name); //printing class name
                    Console.WriteLine("-------------------------------------");
                    
                    //getting all fields
                    var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic| BindingFlags.Instance);
                    foreach (var field in fields) 
                    {
                        if (field.IsDefined(typeof(CompilerGeneratedAttribute), false)) //reduce compiler data
                        {
                            continue;
                        }
                        Console.WriteLine($"Name:{field.Name.Trim()}|| data types:{field.FieldType.Name}");
                    }


                    //getting all properties
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance); //get all data public private protected and others
                    foreach (var property in properties) 
                    {

                        if (property.PropertyType.IsGenericType) //for generic types
                        {
                            
                            var genericArg = property.PropertyType.GetGenericArguments();
                            var gnType = string.Join(", ", genericArg.Select(t => t.Name));
                            Console.WriteLine($"Name:{property.Name}||Type:{property.PropertyType.Name.Split('`')[0]} || genArg:{gnType}");
                            
                            //get generic type and its properties name
                            var genericType = property.PropertyType.GetGenericArguments()[0];
                            var getProp = genericType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                            Console.WriteLine("------------generic class information-----------------");
                            Console.WriteLine(genericType.Name);
                            foreach (var prop in getProp)
                            {
                                Console.WriteLine($"Name:{prop.Name}||Data-type:{prop.PropertyType.Name}");
                            }
                            Console.WriteLine("------------generic class end-----------------");
                        }
                        else
                        {
                            Console.WriteLine($"Name: {property.Name}|| Type:{property.PropertyType.Name}"); // normal properties
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
