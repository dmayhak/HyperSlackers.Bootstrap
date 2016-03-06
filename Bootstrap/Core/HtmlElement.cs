using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using HyperSlackers.Bootstrap.Extensions;
using System.Web;
using System.Text;

namespace HyperSlackers.Bootstrap.Core
{
	//! there are TWO classes here -- one is plain, the other generic one provides common helpers. pick the right one to inherit from


    /// <summary>
    /// Base class for Control HTML elements
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
	public abstract class HtmlElement<TControl> : HtmlElement where TControl : HtmlElement<TControl>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement{TControl}"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
		internal HtmlElement(string tag)
			: base(tag)
		{
			Contract.Requires<ArgumentNullException>(tag != null, "tag");
        }

        /// <summary>
        /// Sets the control's id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
		public TControl Id(string id)
		{
			Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
			Contract.Ensures(Contract.Result<TControl>() != null);

			this.id = id;

			// some objects just render from attributes, so we gotta make sure it's in there as well
			if (!id.IsNullOrWhiteSpace())
			{
                htmlAttributes.AddOrReplaceHtmlAttribute("id", id);
			}

			return (TControl)this;
		}

        /// <summary>
        /// Adds a CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
		public TControl Class(string cssClass)
		{
			Contract.Requires<ArgumentNullException>(cssClass != null, "cssClass");
			Contract.Ensures(Contract.Result<TControl>() != null);

            AddClass(cssClass);

			return (TControl)this;
        }

        /// <summary>
        /// Adds a CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
		public TControl Style(string property, string value)
        {
            Contract.Requires<ArgumentNullException>(property != null, "property");
            Contract.Ensures(Contract.Result<TControl>() != null);

            htmlAttributes.AddOrReplaceCssStyle(property , value);

            return (TControl)this;
        }

        /// <summary>
        /// Adds/merges HTML data- attributes.
        /// </summary>
        /// <param name="htmlDataAttributes">The HTML data attributes.</param>
        /// <returns></returns>
		public TControl HtmlDataAttributes(object htmlDataAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlDataAttributes != null, "htmlDataAttributes");
			Contract.Ensures(Contract.Result<TControl>() != null);

			base.MergeHtmlDataAttributes(htmlDataAttributes);

			return (TControl)this;
		}

        /// <summary>
        /// Adds/merges HTML attributes.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
		public virtual TControl HtmlAttribute(string key, object value)
		{
			Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
			//x Contract.Requires<ArgumentNullException>(value != null, "value");
			Contract.Ensures(Contract.Result<TControl>() != null);

            htmlAttributes.AddOrReplaceHtmlAttribute(key, value);

			return (TControl)this;
		}

        /// <summary>
        /// Adds/merges HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
		public TControl HtmlAttributes(IDictionary<string, object> htmlAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
			Contract.Ensures(Contract.Result<TControl>() != null);

			base.MergeHtmlAttributes(htmlAttributes);

			return (TControl)this;
		}

        /// <summary>
        /// Adds/merges HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
		public TControl HtmlAttributes(object htmlAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
			Contract.Ensures(Contract.Result<TControl>() != null);

			base.MergeHtmlAttributes(htmlAttributes);

			return (TControl)this;
		}
	}

    /// <summary>
    /// Base class for HTML elements
    /// </summary>
	public abstract class HtmlElement
	{
        readonly internal IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
        readonly internal string tag = string.Empty;
		internal string id = string.Empty;
        readonly internal List<string> requiredCssClasses = new List<string>(); // TODO: what use is this? do we need it?
        readonly internal Dictionary<string, string> requiredCssStyles = new Dictionary<string, string>(); // TODO: what use is this? do we need it?

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
		internal HtmlElement(string tag)
		{
			Contract.Requires<ArgumentNullException>(tag != null, "tag");

			this.tag = tag;
		}

        /// <summary>
        /// Gets the end tag.
        /// </summary>
        /// <value>
        /// The end tag.
        /// </value>
		internal virtual string EndTag
		{
			get
			{
				Contract.Ensures(Contract.Result<string>() != null);

				if (tag.IsNullOrWhiteSpace())
				{
					return string.Empty;
				}

				return "</{0}>".FormatWith(tag);
			}
		}

        /// <summary>
        /// Gets the start tag.
        /// </summary>
        /// <value>
        /// The start tag.
        /// </value>
		internal virtual string StartTag
		{
			get
			{
				Contract.Ensures(Contract.Result<string>() != null);

				if (tag.IsNullOrWhiteSpace())
				{
					return string.Empty;
				}

				TagBuilder tagBuilder = new TagBuilder(tag);

				tagBuilder.MergeHtmlAttributes(htmlAttributes.FormatHtmlAttributes());

				return tagBuilder.ToString(TagRenderMode.StartTag);
			}
		}

        internal virtual string ToHtmlString()
        {
            return ToHtmlString(string.Empty);
        }

        internal virtual string ToHtmlString(string innerHtml)
        {
            return ToHtmlString(new HtmlString(innerHtml));
        }

        internal virtual string ToHtmlString(IHtmlString innerHtml)
        {
            StringBuilder tag = new StringBuilder();

            tag.Append(StartTag);
            tag.Append(innerHtml);
            tag.Append(EndTag);

            return tag.ToString();
        }

        /// <summary>
        /// Adds a CSS class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
		protected void AddClass(string className)
		{
            htmlAttributes.AddIfNotExistsCssClass(className);
		}

        /// <summary>
        /// Removes a CSS class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
		protected void RemoveClass(string className)
		{
            htmlAttributes.RemoveCssClass(className);
        }

        /// <summary>
        /// Adds a CSS style.
        /// </summary>
        /// <param name="className">Name of the class.</param>
		protected void AddStyle(string property, string value)
        {
            htmlAttributes.AddOrReplaceCssStyle(property, value);
        }

        /// <summary>
        /// Removes a CSS style.
        /// </summary>
        /// <param name="className">Name of the class.</param>
		protected void RemoveStyle(string property)
        {
            htmlAttributes.RemoveCssClass(property);
        }

        protected void EnsureRequiredCssClasses()
        {
            foreach (var item in requiredCssClasses)
            {
                AddClass(item);
            }
        }

        protected void EnsureRequiredCssStyles()
        {
            foreach (var item in requiredCssStyles)
            {
                AddStyle(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Removes an HTML attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        protected void RemoveHtmlAttribute(string key)
        {
            // TODO: move this logic to DIctionaryExtensions?
            if (key.IsNullOrWhiteSpace())
            {
                return;
            }

            if (htmlAttributes.ContainsKey(key))
            {
                htmlAttributes.Remove(key);
            }
        }

        protected void ReplaceHtmlAttribute(string key, string value)
        {
            htmlAttributes.AddOrReplaceHtmlAttribute(key, value);
        }

        /// <summary>
        /// Adds/merges HTML attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
		protected void AddOrReplaceHtmlAttribute(string key, string value)
		{
            htmlAttributes.AddOrReplaceHtmlAttribute(key, (object)value);
		}

        /// <summary>
        /// Merges the HTML attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
		protected void MergeHtmlAttribute(string key, string value)
		{
            htmlAttributes.AddOrReplaceHtmlAttribute(key, (object)value);
		}

        /// <summary>
        /// Merges the HTML data- attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
		protected void MergeHtmlDataAttributes(object htmlDataAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlDataAttributes != null, "htmlDataAttributes");

            MergeHtmlAttributes(htmlDataAttributes.ToHtmlDataAttributes());
		}

        /// <summary>
        /// Merges the HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
		protected void MergeHtmlAttributes(IDictionary<string, object> htmlAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");

			this.htmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes);
		}

        /// <summary>
        /// Merges the HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
		protected void MergeHtmlAttributes(object htmlAttributes)
		{
			Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");

            MergeHtmlAttributes(htmlAttributes.ToDictionary().FormatHtmlAttributes());
		}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return ToHtmlString();
		}

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

        /// <summary>
        /// Gets the <see cref="T:System.Type" /> of the current instance.
        /// </summary>
        /// <returns>
        /// The exact runtime type of the current instance.
        /// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}
	}
}