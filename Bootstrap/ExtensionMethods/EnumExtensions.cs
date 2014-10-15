using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumerationValue)
        {
            Contract.Requires<ArgumentNullException>(enumerationValue != null, "enumerationValue");

            Type type = enumerationValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            MemberInfo[] member = type.GetMember(enumerationValue.ToString());

            if (member != null && (int)member.Length > 0)
            {
                object[] customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                object[] objArray = member[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (customAttributes != null && (int)customAttributes.Length > 0)
                {
                    return ((DescriptionAttribute)customAttributes[0]).Description;
                }

                if (objArray != null && (int)objArray.Length > 0)
                {
                    return ((DisplayAttribute)objArray[0]).Name;
                }
            }

            return enumerationValue.ToString();
        }
    }
}
