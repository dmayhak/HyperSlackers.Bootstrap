using HyperSlackers.Bootstrap.Core;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// A Bootstrap Carousel panel accepting any HTML content.
    /// </summary>
    public class CarouselCustomItem : DisposableHtmlElement
	{
		internal readonly UrlHelper urlHelper;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarouselCustomItem"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="isFirstItem">if set to <c>true</c> [is first item].</param>
		internal CarouselCustomItem(TextWriter writer, UrlHelper urlHelper, bool isFirstItem)
            : base(writer)
		{
            Contract.Requires<ArgumentNullException>(writer != null, "writer");
            Contract.Requires<ArgumentNullException>(urlHelper != null, "urlHelper");

			this.urlHelper = urlHelper;

            if (isFirstItem)
            {
                this.textWriter.Write("<div class=\"item active\">");
            }
            else
            {
                this.textWriter.Write("<div class=\"item\">");
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
                    this.textWriter.Write("</div>");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}