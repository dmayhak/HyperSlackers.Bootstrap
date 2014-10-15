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
    public class TreeBuilder<TModel> : DisposableHtmlElement<TModel, Tree>
    {
        private bool disposed = false;

        internal TreeBuilder(HtmlHelper<TModel> html, Tree tree)
            : base(html, tree)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tree != null, "tree");

            this.textWriter.Write(this.element.StartTag);
        }

        public TreeHeaderBuilder<TModel> BeginHeader(TreeHeader header)
        {
            Contract.Requires<ArgumentNullException>(header != null, "header");
            Contract.Ensures(Contract.Result<TreeHeaderBuilder<TModel>>() != null);

            if (this.element.collapsed.HasValue && !header.collapsed.HasValue)
            {
                header.collapsed = this.element.collapsed;
            }

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
                    //this.textWriter.Write("");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}
