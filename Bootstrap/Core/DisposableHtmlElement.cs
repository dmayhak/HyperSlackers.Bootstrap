using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for HTML Elements that appear inside "using" statements. ensures the end tag is rendered when going out of scope.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    public abstract class DisposableHtmlElement<TModel, TElement> : DisposableHtmlElement<TElement> where TElement : HtmlElement
    {
        internal readonly HtmlHelper<TModel> html;
        internal readonly AjaxHelper<TModel> ajax;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableHtmlElement{TModel, TElement}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="element">The element.</param>
        internal DisposableHtmlElement(HtmlHelper<TModel> html, TElement element)
            : base(html.ViewContext.Writer, element)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(element != null, "element");

            this.html = html;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableHtmlElement{TModel, TElement}"/> class.
        /// </summary>
        /// <param name="ajax">The ajax.</param>
        /// <param name="element">The element.</param>
        internal DisposableHtmlElement(AjaxHelper<TModel> ajax, TElement element)
            : base(ajax.ViewContext.Writer, element)
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(element != null, "element");

            this.ajax = ajax;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (!this.doNotRender)
                    {
                        // done in base classthis.textWriter.Write(this.element.EndTag);
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Base class for HTML Elements that appear inside "using" statements. ensures the end tag is rendered when going out of scope.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    public abstract class DisposableHtmlElement<TElement> : DisposableHtmlElement where TElement : HtmlElement
    {
        internal readonly TElement element;
        internal bool doNotRender = false;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableHtmlElement{TElement}"/> class.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        /// <param name="element">The element.</param>
        internal DisposableHtmlElement(TextWriter textWriter, TElement element)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");
            Contract.Requires<ArgumentNullException>(element != null, "element");

            this.element = element;

            if (!this.doNotRender)
            {
                // this needs to be called in overridden classes to allow constructors to do stuff first...
                //x this.textWriter.Write(this.element.StartTag);
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (!this.doNotRender)
                    {
                        this.textWriter.Write(this.element.EndTag);
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Base class for HTML Elements that appear inside "using" statements. ensures the end tag is rendered when going out of scope.
    /// </summary>
    public abstract class DisposableHtmlElement : IDisposable
    {
        internal readonly TextWriter textWriter;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableHtmlElement"/> class.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        internal DisposableHtmlElement(TextWriter textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");

            this.textWriter = textWriter;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //

                    this.disposed = true;
                }
            }
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
