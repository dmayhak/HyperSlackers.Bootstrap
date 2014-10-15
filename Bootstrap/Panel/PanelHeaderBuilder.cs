using HyperSlackers.Bootstrap.Core;
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

namespace HyperSlackers.Bootstrap.Controls
{
    public class PanelHeaderBuilder : DisposableHtmlElement
    {
        private bool disposed = false;

        internal PanelHeaderBuilder(TextWriter textWriter, Panel panel)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");
            Contract.Requires<ArgumentNullException>(panel != null, "panel");

            if (panel.collapsible)
            {
                this.textWriter.Write("<div class=\"panel-heading{1}\" data-toggle=\"collapse\" data-target=\"{0}\" style=\"cursor:pointer;\">".FormatWith("#" + panel.id + "Collapse", panel.collapsed ? " collapsed" : string.Empty));
            }
            else
            {
                this.textWriter.Write("<div class=\"panel-heading\">");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
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