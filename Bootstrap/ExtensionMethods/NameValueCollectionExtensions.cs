using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class NameValueCollectionExtensions
    {
        public static RouteValueDictionary ToRouteValues(this NameValueCollection queryString)
        {
            if (queryString == null || !queryString.HasKeys())
            {
                return new RouteValueDictionary();
            }
            RouteValueDictionary routeValueDictionaries = new RouteValueDictionary();
            string[] allKeys = queryString.AllKeys;
            for (int i = 0; i < (int)allKeys.Length; i++)
            {
                string str = allKeys[i];
                routeValueDictionaries.Add(str, queryString[str]);
            }
            return routeValueDictionaries;
        }
    }
}
