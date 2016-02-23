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
        public static IDictionary<string, object> AddIfNotExist(this IDictionary<string, object> source, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }

            return source;
        }

        public static IDictionary<string, object> AddIfNotExistsCssClass(this IDictionary<string, object> source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return source;
            }

            string key = "class";

            if (source.ContainsKey(key))
            {
                // split incoming class name on ' ' just in case multiple items are being passed at one time
                List<string> existingValues = source[key].ToString().Trim().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();
                List<string> newValues = value.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();

                source[key] = String.Join(" ", existingValues.Union(newValues).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList());
            }
            else if (!value.IsNullOrWhiteSpace())
            {
                source.Add(key, value);
            }

            return source;
        }

        /// <summary>
        /// Adds the CSS style if it does not already exist. If the CSS property is already defined, nothing is added.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AddIfNotExistsCssStyle(this IDictionary<string, object> source, string property , string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (property.IsNullOrWhiteSpace() || value.IsNullOrWhiteSpace())
            {
                return source;
            }

            string key = "style";

            if (source.ContainsKey(key))
            {
                // create dictionary by splitting on  ';', then on ':'
                var dict = source[key].ToString().Trim().Split(';').Select(s => s.Split(':')).Where(s => s.Length > 1 && !String.IsNullOrEmpty(s[0].Trim()) && !String.IsNullOrEmpty(s[1].Trim())).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

                if (!dict.ContainsKey(property))
                {
                    dict[property] = value;
                }

                source[key] = String.Join(" ", dict.Select(s => "{Key}: {Value};".FormatWith(s)));
            }
            else if (!value.IsNullOrWhiteSpace())
            {
                source.Add(key, "{0}: {1};".FormatWith(property.Trim(), value.Trim()));
            }

            return source;
        }

        public static IDictionary<string, object> AddOrReplaceCssStyle(this IDictionary<string, object> source, string property, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (property.IsNullOrWhiteSpace() || value.IsNullOrWhiteSpace())
            {
                return source;
            }

            string key = "style";

            if (source.ContainsKey(key))
            {
                // create dictionary by splitting on  ';', then on ':'
                var dict = source[key].ToString().Trim().Split(';').Select(s => s.Split(':')).Where(s => s.Length > 1 && !String.IsNullOrEmpty(s[0].Trim()) && !String.IsNullOrEmpty(s[1].Trim())).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

                dict[property] = value;

                source[key] = String.Join(" ", dict.Select(s => "{Key}: {Value};".FormatWith(s)));
            }
            else if (!value.IsNullOrWhiteSpace())
            {
                source.Add(key, "{0}: {1};".FormatWith(property.Trim(), value.Trim()));
            }

            return source;
        }

        /// <summary>
        /// Replaces the HTML attribute.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AddOrReplaceHtmlAttribute(this IDictionary<string, object> source, string key, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            //x Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (key.IsNullOrWhiteSpace())
            {
                return source;
            }

            source[key] = value;

            return source;
        }

        /// <summary>
        /// Formats the HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds or replaces the specific attribute.
        /// For class and style, you may want to use the appropriate xxxCssClass and xxxCssStyle methods instead.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AddOrReplaceHtmlAttribute(this IDictionary<string, object> source, string key, object value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");

            if (key.IsNullOrWhiteSpace())
            {
                return source;
            }

            source[key] = value;

            return source;
        }

        /// <summary>
        /// Adds or replaces the specific attributes.
        /// For class and style, you may want to use the appropriate xxxCssClass and xxxCssStyle methods instead.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AddOrReplaceHtmlAttributes(this IDictionary<string, object> source, IDictionary<string, object> htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");

            if (htmlAttributes == null)
            {
                return source;
            }

            foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
            {
                source.AddOrReplaceHtmlAttribute(htmlAttribute.Key, htmlAttribute.Value);
            }

            return source;
        }

        /// <summary>
        /// Removes the HTML attribute.
        /// For class and style, you may want to use the appropriate xxxCssClass and xxxCssStyle methods instead.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static IDictionary<string, object> RemoveHtmlAttribute(this IDictionary<string, object> source, string key)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");

            if (key.IsNullOrWhiteSpace())
            {
                return source;
            }

            if (source.ContainsKey(key))
            {
                source.Remove(key);
            }

            return source;
        }

        /// <summary>
        /// Removes the CSS style.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IDictionary<string, object> RemoveCssStyle(this IDictionary<string, object> source, string property)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (property.IsNullOrWhiteSpace())
            {
                return source;
            }

            string key = "style";

            if (source.ContainsKey(key))
            {
                // create dictionary by splitting on  ';', then on ':'
                var dict = source[key].ToString().Trim().Split(';').Select(s => s.Split(':')).Where(s => s.Length > 1 && !String.IsNullOrEmpty(s[0].Trim()) && !String.IsNullOrEmpty(s[1].Trim())).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

                if (dict.ContainsKey(property))
                {
                    dict.Remove(property);
                }

                source[key] = String.Join(" ", dict.Select(s => "{Key}: {Value};".FormatWith(s)));
            }

            return source;
        }

        /// <summary>
        /// Removes the CSS class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IDictionary<string, object> RemoveCssClass(this IDictionary<string, object> source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, "source");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return source;
            }

            string key = "class";

            if (source.ContainsKey(key))
            {
                // split incoming on ' ' just in case multiple items are being passed at one time
                List<string> existingValues = source[key].ToString().Trim().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Distinct(StringComparer.InvariantCultureIgnoreCase).ToList();

                if (existingValues.Contains(value))
                {
                    existingValues.Remove(value);
                }

                source[key] = String.Join(" ", existingValues.Distinct(StringComparer.InvariantCultureIgnoreCase).ToList());
            }

            return source;
        }

    }
}
