using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionRecursion
{
    class XMLFormatter
    {
        public static string Convert(object obj)
        {
            string output = string.Empty;
            Type instance = obj.GetType();
            output += $"<{instance.Name}>\n";
            PropertyInfo[] properties = instance.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
            foreach (PropertyInfo property in properties)
            {
                output += $"\t<{property.Name}>";
                object? value = property.GetValue(obj);
                if (value is IEnumerable enumerableValue && !(value is string))
                {

                    foreach (var item in enumerableValue)
                    {
                        Type type = item.GetType();
                        if (type.IsClass)
                        {
                            output += Convert(item);
                            output += "\n";
                        }
                        else
                        {
                            output += $"\n<{item.GetType().Name}>{item}</{item.GetType().Name}>";
                        }
                    }

                }
                else
                {
                    output += $"{value}";
                }

                output += $"</{property.Name}>\n";
            }
            output += $"</{instance.Name}>";

            return output;
        }
    }
}
