using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HyperSlackers.Bootstrap.Extensions;
using System.ComponentModel;
using System.Web.Mvc;

namespace HyperSlackers.Bootstrap.Core
{
    public class WrapperTag : IHtmlString
    {
        internal string tag;
        internal string id = string.Empty;
        internal IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();

        public WrapperTag(string tag)
        {
            Contract.Requires<ArgumentNullException>(!tag.IsNullOrWhiteSpace(), "tag");

            this.tag = tag;
        }

        /// <summary>
        /// Sets the control's id attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual WrapperTag Id(string id)
        {
            Contract.Requires<ArgumentNullException>(id != null, "id");
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            this.id = id;
            htmlAttributes.AddOrReplaceHtmlAttribute("id", id);

            return this;
        }

        /// <summary>
        /// Adds a role attribute to the control.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual WrapperTag Role(string role)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            htmlAttributes.AddOrReplaceHtmlAttribute("role", role);

            return this;
        }

        /// <summary>
        /// Adds or removes the 'active' css class.
        /// </summary>
        /// <param name="active">active if true, not active if false.</param>
        /// <returns></returns>
        public virtual WrapperTag Active(bool active = true)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            if (active)
            {
                htmlAttributes.AddIfNotExistsCssClass("active");
            }
            else
            {
                htmlAttributes.RemoveCssClass("active");
            }

            return this;
        }

        /// <summary>
        /// Adds or removes the 'disabled' css class.
        /// </summary>
        /// <param name="active">disabled if true, not disabled if false.</param>
        /// <returns></returns>
        public virtual WrapperTag Disabled(bool disabled = true)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            if (disabled)
            {
                htmlAttributes.AddIfNotExistsCssClass("disabled");
            }
            else
            {
                htmlAttributes.RemoveCssClass("disabled");
            }

            return this;
        }

        /// <summary>
        /// Adds a CSS class to the control.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public virtual WrapperTag Class(string cssClass)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            htmlAttributes.AddIfNotExistsCssClass(cssClass);

            return this;
        }

        /// <summary>
        /// Adds an HTML attribute to the control.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public virtual WrapperTag HtmlAttribute(string key, object value)
        {
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            //x Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Ensures(Contract.Result<WrapperTag>() != null);

            htmlAttributes.AddOrReplaceHtmlAttribute(key, value);

            return this;
        }

        /// <summary>
        /// Returns an HTML-encoded string for the wrapper tag
        /// with {0} in the position to render the inner html.
        /// </summary>
        /// <returns>
        /// An HTML-encoded string.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            TagBuilder tagBuilder = new TagBuilder(tag);

            if (!id.IsNullOrWhiteSpace())
            {
                tagBuilder.Attributes.Add("id", id);
            }

            tagBuilder.MergeHtmlAttributes(htmlAttributes.FormatHtmlAttributes());

            tagBuilder.InnerHtml = "{0}";

            return tagBuilder.ToString(TagRenderMode.Normal);
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
