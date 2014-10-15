using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for all HTML control objects.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class ControlBase<TControl, TModel> : IHtmlString where TControl : ControlBase<TControl, TModel>
    {
        internal HtmlHelper<TModel> html;
        internal string id = string.Empty;
        internal IDictionary<string, object> controlHtmlAttributes = new Dictionary<string, object>();
        internal int? index; // in case the control is a member of a control list
        internal CursorType? cursorType;

        [ContractInvariantMethod]
        private void ObjectInvariant () 
        {
            Contract.Invariant(this.html != null);
            Contract.Invariant(this.id != null);
            Contract.Invariant(this.controlHtmlAttributes != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlBase{TControl, TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        protected ControlBase(HtmlHelper<TModel> html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.html = html;
        }

        /// <summary>
        /// Sets the control's id attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TControl ControlId(string id)
        {
            Contract.Requires<ArgumentNullException>(id != null, "id");
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.id = id;
            this.controlHtmlAttributes.AddOrReplace("id", id);

            return (TControl)this;
        }

        /// <summary>
        /// Adds a CSS class to the control.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public virtual TControl ControlClass(string cssClass)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.AddClass(cssClass);

            return (TControl)this;
        }

        /// <summary>
        /// Adds an HTML attribute to the control.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public virtual TControl ControlHtmlAttribute(string key, object value)
        {
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            //x Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttribute(key, value);

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML attributes to the control.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TControl ControlHtmlAttributes(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML attributes to the control.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TControl ControlHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttributes(htmlAttributes);

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML data- attributes to the control.
        /// </summary>
        /// <param name="dataAttributes">The data attributes.</param>
        /// <returns></returns>
        public virtual TControl ControlHtmlDataAttributes(object dataAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(dataAttributes != null, "dataAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttributes(dataAttributes.ToHtmlDataAttributes());

            return (TControl)this;
        }

        /// <summary>
        /// Sets the mouse cursor for the control.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <returns></returns>
        public virtual TControl Cursor(CursorType cursor)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.cursorType = cursor;
            this.ControlHtmlAttribute("style", "cursor: {0};".FormatWith(Helpers.GetCssClass(cursor)));

            return (TControl)this;
        }

        /// <summary>
        /// Sets the control's tab index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        internal virtual TControl Index(int index)
        {
            Contract.Requires<ArgumentOutOfRangeException>(index >= 0);
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.index = index;

            return (TControl)this;
        }

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>
        /// An HTML-encoded string.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return Render();
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
            return this.ToHtmlString();
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

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual string Render()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return RenderControl();
        }

        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            throw new NotImplementedException(); 
        }
    }
}
