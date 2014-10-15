using HyperSlackers.Bootstrap.Controls;
using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TreeItemBuilder<TModel> : DisposableHtmlElement<TModel, TreeItem>
    {
        private bool disposed = false;

        internal TreeItemBuilder(HtmlHelper<TModel> html, TreeItem item)
            : base(html, item)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(item != null, "item");

            this.textWriter.Write(this.element.StartTag);
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //this.textWriter.Write("");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}
