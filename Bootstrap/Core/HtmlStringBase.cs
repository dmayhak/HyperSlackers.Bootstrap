using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for some HTML controls.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    public abstract class HtmlStringBase<TControl> : IHtmlString where TControl : HtmlStringBase<TControl>
    {
        internal string id = string.Empty;
        internal IDictionary<string, object> attributes = new Dictionary<string, object>();
        internal Form form; // this is set if element is created on a form (allows to set common widths for labels, etc...)

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlStringBase{TControl}"/> class.
        /// </summary>
        protected HtmlStringBase()
        {
        }

        /// <summary>
        /// Sets the control's form.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        internal TControl Form(Form form)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.form = form;

            return (TControl)this;
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

            attributes.AddOrReplaceHtmlAttribute("id", id);

            return (TControl)this;
        }

        /// <summary>
        /// Adds the specified CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public TControl Class(string cssClass)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            if (!cssClass.IsNullOrWhiteSpace())
            {
                attributes.AddIfNotExistsCssClass(cssClass);
            }

            return (TControl)this;
        }

        /// <summary>
        /// Adds/merges HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public TControl HtmlAttributes(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            if (htmlAttributes != null)
            {
                attributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToDictionary());
            }

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

            attributes.AddOrReplaceHtmlAttributes(htmlAttributes);

            return (TControl)this;
        }

        /// <summary>
        /// Adds/merges HTML data- attributes.
        /// </summary>
        /// <param name="dataAttributes">The data attributes.</param>
        /// <returns></returns>
        public TControl DataAttributes(object dataAttributes)
        {
            Contract.Requires<ArgumentNullException>(dataAttributes != null, "dataAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            attributes.AddOrReplaceHtmlAttributes(dataAttributes.ToHtmlDataAttributes());

            return (TControl)this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>
        /// An HTML-encoded string.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract string ToHtmlString();

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
            return Equals(obj);
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
            return GetHashCode();
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
            return GetType();
        }
    }
}
