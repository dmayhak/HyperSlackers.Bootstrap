using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class DictionaryExtensions
    {
        public static IDictionary<string, object> AddIfNotExist(this IDictionary<string, object> data, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (!data.ContainsKey(key))
            {
                data.Add(key, value);
            }

            return data;
        }

        public static IDictionary<string, object> AddClass(this IDictionary<string, object> data, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            //x Contract.Requires<ArgumentException>(!value.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            return data.AddOrMergeCssClass("class", value);
        }

        private static IDictionary<string, object> AddOrMergeCssClass(this IDictionary<string, object> data, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return data;
            }

            if (data.ContainsKey(key))
            {
                // split incoming class name on ' ' just in case multiple items are being passed at one time
                string existing = data[key].ToString();
                string[] newItems = value.Split(' ');
                foreach (var item in newItems)
                {
                    if (!item.IsNullOrWhiteSpace() && !Regex.IsMatch(existing, "(^|\\s){0}($|\\s)".FormatWith(item)))
                    {
                        data[key] += " " + item;
                    }
                }
            }
            else if (!value.IsNullOrWhiteSpace())
            {
                data.Add(key, value);
            }

            return data;
        }

        public static IDictionary<string, object> AddOrReplace(this IDictionary<string, object> data, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            //x Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (key.IsNullOrWhiteSpace())
            {
                return data;
            }

            if (!data.ContainsKey(key))
            {
                data.Add(key, value);
            }
            else
            {
                data[key] = value;
            }

            return data;
        }

        public static IDictionary<string, object> FormatHtmlAttributes(this IDictionary<string, object> htmlAttributes)
        {
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);
            
            if (htmlAttributes == null)
            {
                return new Dictionary<string, object>();
            }

            IDictionary<string, object> attributes = new Dictionary<string, object>();

            foreach (string key in htmlAttributes.Keys)
            {
                attributes.Add(key.Replace('\u005F', '-'), htmlAttributes[key]);
            }

            return attributes;
        }

        public static void MergeHtmlAttribute(this IDictionary<string, object> source, string key, object value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");

            if (key.IsNullOrWhiteSpace())
            {
                return;
            }

            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
            else if ((key.ToLower() == "class") || (key.ToLower() == "style"))
            {
                source[key] = string.Concat(source[key], " ", value);
            }
            else
            {
                source[key] = value;
            }
        }

        public static void MergeHtmlAttributes(this IDictionary<string, object> source, IDictionary<string, object> htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            
            if (htmlAttributes == null)
            {
                return;
            }

            foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
            {
                source.MergeHtmlAttribute(htmlAttribute.Key, htmlAttribute.Value);
            }
        }

        public static IDictionary<string, object> RemoveClass(this IDictionary<string, object> data, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            //x Contract.Requires<ArgumentException>(!value.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            return data.RemoveCssClass("class", value);
        }

        private static IDictionary<string, object> RemoveCssClass(this IDictionary<string, object> data, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(data != null, "data");
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return data;
            }

            if (data.ContainsKey(key))
            {
                // split incoming class name on ' ' just in case multiple items are being passed at one time
                string existing = data[key].ToString();
                string[] newItems = value.Split(' ');
                foreach (var item in newItems)
                {
                    if (!item.IsNullOrWhiteSpace() && Regex.IsMatch(existing, "(^|\\s){0}($|\\s)".FormatWith(item)))
                    {
                        data[key] = Regex.Replace(existing, "(^|\\s){0}($|\\s)".FormatWith(item), string.Empty).Replace("  ", " ");
                    }
                }
            }

            return data;
        }

    }
}
