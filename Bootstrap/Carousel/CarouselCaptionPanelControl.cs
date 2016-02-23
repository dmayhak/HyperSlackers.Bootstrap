using HyperSlackers.Bootstrap.Core;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// A Bootstrap panel allowing arbitrary HTML caption.
    /// </summary>
    public class CarouselCaptionPanel : DisposableHtmlElement
	{
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarouselCaptionPanel"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
		internal CarouselCaptionPanel(TextWriter writer)
            : base(writer)
		{
            Contract.Requires<ArgumentNullException>(writer != null, "writer");

            textWriter.Write("<div class=\"carousel-caption\">");
		}

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div></div>");

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}