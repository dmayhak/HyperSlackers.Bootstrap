using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    public abstract class BuilderBase<TElement> : IDisposable where TElement : HtmlElement
    {
        internal readonly HtmlHelper html;
        internal readonly AjaxHelper ajax;
        internal readonly TElement element;
        internal readonly TextWriter textWriter;
        private bool disposed = false;

        internal BuilderBase(HtmlHelper html, TElement element)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(element != null, "element");

            this.element = element;
            this.html = html;
            this.textWriter = html.ViewContext.Writer;

            this.textWriter.Write(this.element.StartTag);
        }

        internal BuilderBase(AjaxHelper ajax, TElement element)
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(element != null, "element");

            this.element = element;
            this.ajax = ajax;
            this.textWriter = ajax.ViewContext.Writer;

            this.textWriter.Write(this.element.StartTag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write(this.element.EndTag);

                    this.disposed = true;
                }
            }
        }
    }

	public abstract class BuilderBase<TModel, TElement> : IDisposable where TElement : HtmlElement
	{
        private bool disposed = false;
		internal readonly HtmlHelper<TModel> html;
		internal readonly AjaxHelper<TModel> ajax;
		internal readonly TextWriter textWriter;
		internal readonly TElement element;

		internal BuilderBase(HtmlHelper<TModel> html, TElement element)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(element != null, "element");

			this.element = element;
			this.html = html;
			this.textWriter = html.ViewContext.Writer;
    		this.textWriter.Write(this.element.StartTag);
		}

		internal BuilderBase(AjaxHelper<TModel> ajax, TElement element)
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(element != null, "element");

			this.element = element;
			this.ajax = ajax;
			this.textWriter = ajax.ViewContext.Writer;

			this.textWriter.Write(this.element.StartTag);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write(this.element.EndTag);

                    this.disposed = true;
                }
            }
        }
	}
}