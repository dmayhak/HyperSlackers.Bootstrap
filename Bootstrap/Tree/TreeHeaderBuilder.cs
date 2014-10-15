using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TreeHeaderBuilder<TModel> : DisposableHtmlElement<TModel, TreeHeader>
    {
        private bool disposed = false;

        internal TreeHeaderBuilder(HtmlHelper<TModel> html, TreeHeader header)
            : base(html, header)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(header != null, "header");

            this.textWriter.Write(this.element.StartTag);

            this.textWriter.Write("<ul class=\"nav nav-list tree\">");
        }

        public TreeHeaderBuilder<TModel> BeginHeader(TreeHeader header)
        {
            Contract.Requires<ArgumentNullException>(header != null, "header");
            Contract.Ensures(Contract.Result<TreeHeaderBuilder<TModel>>() != null);

            return new TreeHeaderBuilder<TModel>(this.html, header);
        }

        public TreeItemBuilder<TModel> BeginItem(TreeItem item)
        {
            Contract.Requires<ArgumentNullException>(item != null, "item");
            Contract.Ensures(Contract.Result<TreeItemBuilder<TModel>>() != null);

            return new TreeItemBuilder<TModel>(this.html, item);
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write("</ul>");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}
