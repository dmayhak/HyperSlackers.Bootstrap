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
    public class TreeControl<TModel> : ControlBase<TreeControl<TModel>, TModel>
    {
        internal Tree tree { get; set; }

        internal TreeControl(HtmlHelper<TModel> html, Tree tree)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tree != null, "tree");

            this.tree = tree;
        }
    }
}
