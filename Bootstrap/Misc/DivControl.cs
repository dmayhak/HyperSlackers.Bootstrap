using System;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class DivControl : IDisposable
	{
		private readonly HtmlHelper html;
		private bool disposed = false;

		public DivControl(HtmlHelper html, string cssClass, object htmlAttributes)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");

			this.html = html;
			TagBuilder tagBuilder = new TagBuilder("div");
			tagBuilder.AddCssClass(cssClass);
			tagBuilder.MergeHtmlAttributes(htmlAttributes.ToDictionary().FormatHtmlAttributes());
			html.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
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
                    this.disposed = true;
                    this.html.ViewContext.Writer.Write("</div>");

                    this.disposed = true;
                }
            }
        }
	}
}