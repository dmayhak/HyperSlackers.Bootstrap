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
    public class ModalHeaderBuilder : DisposableHtmlElement
    {
        private bool disposed = false;

        internal ModalHeaderBuilder(TextWriter textWriter, bool isCloseable)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");

            this.textWriter.Write("<div class=\"modal-header\">");
            if (isCloseable)
            {
                this.textWriter.Write("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button>");
            }
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