using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class Icon : IHtmlString
    {
        readonly internal IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
        internal Tooltip tooltip;
        internal Popover popover;
        readonly internal string cssClass;

        internal Icon()
        {
        }

        internal Icon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());

            this.cssClass = cssClass;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return this.ToHtmlString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return this.Equals(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return this.GetType();
        }
    }

    public class Icon<T> : Icon where T : Icon<T>
	{
		internal Icon()
        {
        }

        public Icon(string cssClass)
            : base(cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
        }

        public T Class(string cssClass)
		{
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

            this.htmlAttributes.AddClass(cssClass);

			return (T)this;
		}

        public T Data(object htmlDataAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlDataAttributes != null, "htmlDataAttributes");
            Contract.Ensures(Contract.Result<T>() != null);

			this.htmlAttributes.MergeHtmlAttributes(htmlDataAttributes.ToHtmlDataAttributes());

			return (T)this;
		}

        public T HtmlAttribute(string key, string value)
        {
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

            this.htmlAttributes.Add(key, value);

            return (T)this;
        }

        public T HtmlAttributes(IDictionary<string, object> htmlAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<T>() != null);

			this.htmlAttributes.MergeHtmlAttributes(htmlAttributes);

			return (T)this;
		}

		public T HtmlAttributes(object htmlAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<T>() != null);

			this.htmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

			return (T)this;
		}

		public T Id(string id)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

			this.htmlAttributes.AddOrReplace("id", id);

			return (T)this;
		}

		public T Popover(Popover popover)
		{
            Contract.Requires<ArgumentNullException>(popover != null, "popover");
            Contract.Ensures(Contract.Result<T>() != null);

			this.popover = popover;

			return (T)this;
		}

		public T Popover(string title, string content)
		{
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!content.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

			this.popover = new Popover(title, content);

			return (T)this;
		}

		public T Tooltip(Tooltip tooltip)
		{
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<T>() != null);

			this.tooltip = tooltip;

			return (T)this;
		}

		public T Tooltip(string text)
		{
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

			this.tooltip = new Tooltip(text);

			return (T)this;
		}

        public T Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<T>() != null);

            this.tooltip = new Tooltip(html);

            return (T)this;
        }
	}
}