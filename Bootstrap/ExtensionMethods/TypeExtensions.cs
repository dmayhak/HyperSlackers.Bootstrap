using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class TypeExtensions
    {
        public static bool IsGenericEnumerable(this Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null, "type");

            if (type.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                return true;
            }

            return null != type.GetInterface("IEnumerable`1");
        }
        
        public static bool IsIDictionary(this Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null, "type");

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                return true;
            }

            return type.Name == "RouteValueDictionary";
        }

        public static bool IsNullableEnum(this Type type)
        {
            Contract.Requires<ArgumentNullException>(type != null, "type");

            Type underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType == null)
            {
                return false;
            }

            return underlyingType.IsEnum;
        }
    }
}
