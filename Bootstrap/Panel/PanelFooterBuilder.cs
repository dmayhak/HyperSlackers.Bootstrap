using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class PanelFooterBuilder : DisposableHtmlElement
    {
        private bool disposed = false;

        internal PanelFooterBuilder(TextWriter textWriter)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");

            this.textWriter.Write("<div class=\"panel-footer\">");
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div>");

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}