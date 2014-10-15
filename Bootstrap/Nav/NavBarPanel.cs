using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class NavBarPanelBuilder : DisposableHtmlElement // TODO:  WIP
    {
        readonly internal bool pullRight;
        private bool disposed;

        internal NavBarPanelBuilder(TextWriter textWriter, bool pullRight = false)
            : base(textWriter)
		{
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");

            this.pullRight = pullRight;

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<ul class=\"nav navbar-nav>".FormatWith(this.pullRight ? " navbar-right" : string.Empty));

            this.textWriter.Write(startTag.ToString());
		}



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write("</ul>");

                    this.disposed = true;
                }
            }
        }
    }
}
