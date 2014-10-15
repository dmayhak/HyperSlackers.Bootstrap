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
    public class PanelBodyBuilder : DisposableHtmlElement
    {
        private bool disposed = false;

        internal PanelBodyBuilder(TextWriter textWriter, Panel panel)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");
            Contract.Requires<ArgumentNullException>(panel != null, "panel");

            if (panel.collapsible)
            {
                this.textWriter.Write("<div id=\"{0}Collapse\" class=\"panel-collapse collapse{1}\">".FormatWith(panel.id, panel.collapsed ? string.Empty : " in"));
            }

            this.textWriter.Write("<div class=\"panel-body\">");
        }

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