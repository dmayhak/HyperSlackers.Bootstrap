using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class TagBuilderExtensions
    {
        public static TagBuilder AddCssStyle(this TagBuilder tagBuilder, string styleName, string styleValue)
        {
            Contract.Requires<ArgumentNullException>(tagBuilder != null, "tagBuilder");
            Contract.Requires<ArgumentNullException>(styleName != null, "styleName");
            Contract.Requires<ArgumentException>(!styleName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(styleValue != null, "styleValue");
            Contract.Requires<ArgumentException>(!styleValue.IsNullOrWhiteSpace());

            if (!tagBuilder.Attributes.ContainsKey("style"))
            {
                tagBuilder.Attributes.Add("style", string.Concat(styleName, ":", styleValue, ";"));
            }
            else
            {
                IDictionary<string, string> attributes = tagBuilder.Attributes;
                string item = attributes["style"];
                string[] strArrays = new string[] { item, styleName, ":", styleValue, ";" };
                attributes["style"] = string.Concat(strArrays);
            }
            return tagBuilder;
        }

        public static TagBuilder AddOrMergeAttribute(this TagBuilder tagBuilder, string attributeName, string attributeValue)
        {
            Contract.Requires<ArgumentNullException>(tagBuilder != null, "tagBuilder");
            Contract.Requires<ArgumentNullException>(attributeName != null, "attributeName");
            Contract.Requires<ArgumentException>(!attributeName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(attributeValue != null, "attributeValue");
            Contract.Requires<ArgumentException>(!attributeValue.IsNullOrWhiteSpace());

            if (!tagBuilder.Attributes.ContainsKey(attributeName))
            {
                tagBuilder.Attributes.Add(attributeName, attributeValue);
            }
            else if (!tagBuilder.Attributes[attributeName].Contains(attributeValue))
            {
                IDictionary<string, string> attributes = tagBuilder.Attributes;
                IDictionary<string, string> strs = attributes;
                string str = attributeName;
                string str1 = str;
                attributes[str] = string.Concat(strs[str1], " ", attributeValue);
            }
            return tagBuilder;
        }

        public static TagBuilder AddOrMergeCssClass(this TagBuilder tagBuilder, string attributeValue)
        {
            Contract.Requires<ArgumentNullException>(tagBuilder != null, "tagBuilder");
            Contract.Requires<ArgumentNullException>(attributeValue != null, "attributeValue");
            //x Contract.Requires<ArgumentException>(!attributeValue.IsNullOrWhiteSpace());

            if (attributeValue.IsNullOrWhiteSpace())
            {
                return tagBuilder;
            }

            if (!tagBuilder.Attributes.ContainsKey("class"))
            {
                tagBuilder.Attributes.Add("class", attributeValue);
            }
            else if (!tagBuilder.Attributes["class"].Contains(attributeValue))
            {
                IDictionary<string, string> attributes = tagBuilder.Attributes;
                IDictionary<string, string> strs = attributes;
                attributes["class"] = string.Concat(strs["class"], " ", attributeValue);
            }
            return tagBuilder;
        }

        public static void MergeHtmlAttributes(this TagBuilder tagBuilder, IDictionary<string, object> htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(tagBuilder != null, "tagBuilder");
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");

            foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
            {
                if (!tagBuilder.Attributes.ContainsKey(htmlAttribute.Key))
                {
                    tagBuilder.Attributes.Add(htmlAttribute.Key, (htmlAttribute.Value != null ? htmlAttribute.Value.ToString() : string.Empty));
                }
                else if (htmlAttribute.Key.ToLower() != "class")
                {
                    tagBuilder.Attributes[htmlAttribute.Key] = (htmlAttribute.Value != null ? htmlAttribute.Value.ToString() : string.Empty);
                }
                else
                {
                    tagBuilder.Attributes[htmlAttribute.Key] = string.Concat(tagBuilder.Attributes[htmlAttribute.Key], " ", htmlAttribute.Value);
                }
            }
        }
    }
}
