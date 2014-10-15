using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object data)
        {
            if (data == null)
            {
                return new Dictionary<string, object>();
            }
            if (data.GetType().IsIDictionary())
            {
                return (IDictionary<string, object>)data;
            }
            return HtmlHelper.AnonymousObjectToHtmlAttributes(data);
        }

        public static IDictionary<string, object> ToHtmlDataAttributes(this object data)
        {
            if (data == null)
            {
                return new Dictionary<string, object>();
            }
            IDictionary<string, object> dictionary = data.ToDictionary();
            RouteValueDictionary routeValueDictionaries = new RouteValueDictionary();
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
            {
                routeValueDictionaries.Add(string.Concat("data-", keyValuePair.Key), keyValuePair.Value);
            }
            return routeValueDictionaries;
        }

        public static IDictionary<string, object> ObjectToHtmlAttributesDictionary(this object htmlAttributes)
        {
            IDictionary<string, object> strs = null;
            if (htmlAttributes == null)
            {
                return new Dictionary<string, object>();
            }
            strs = htmlAttributes as IDictionary<string, object> ?? htmlAttributes.ToDictionary();
            return strs;
        }
    }
}
