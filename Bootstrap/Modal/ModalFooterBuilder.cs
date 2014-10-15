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
    public class ModalFooterBuilder : DisposableHtmlElement
    {
        private bool disposed = false;

        internal ModalFooterBuilder(TextWriter textWriter)
            : base(textWriter)
        {
            Contract.Requires<ArgumentNullException>(textWriter != null, "textWriter");

            this.textWriter.Write("<div class=\"modal-footer\">");
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