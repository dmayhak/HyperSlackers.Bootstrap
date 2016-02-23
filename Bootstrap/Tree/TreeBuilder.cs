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

            textWriter.Write(element.StartTag);
        }

        public TreeHeaderBuilder<TModel> BeginHeader(string text)
        {
            Contract.Requires<ArgumentNullException>(!text.IsNullOrWhiteSpace(), "text");
            Contract.Ensures(Contract.Result<TreeHeaderBuilder<TModel>>() != null);

            return BeginHeader(new TreeHeader(text));
        }

        public TreeHeaderBuilder<TModel> BeginHeader(TreeHeader header)
        {
            Contract.Requires<ArgumentNullException>(header != null, "header");
            Contract.Ensures(Contract.Result<TreeHeaderBuilder<TModel>>() != null);

            if (element.collapsed.HasValue && !header.collapsed.HasValue)
            {
                header.collapsed = element.collapsed;
            }

            return new TreeHeaderBuilder<TModel>(html, header);
        }

        public TreeItemBuilder<TModel> BeginItem(TreeItem item)
        {
            Contract.Requires<ArgumentNullException>(item != null, "item");
            Contract.Ensures(Contract.Result<TreeItemBuilder<TModel>>() != null);

            return new TreeItemBuilder<TModel>(html, item);
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //this.textWriter.Write("");

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}
