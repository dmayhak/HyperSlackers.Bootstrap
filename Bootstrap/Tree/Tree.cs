using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class Tree : HtmlElement<Tree>
    {
        //internal List<HtmlElement> items = new List<HtmlElement>();
        internal bool? collapsed = false;

        public Tree()
            : base("div")
        {
            AddClass("tree");
        }

        public Tree(string id)
            : this()
        {
            Id(id);
        }

        public Tree Collapsed(bool collapsed = true)
        {
            Contract.Ensures(Contract.Result<Tree>() != null);

            this.collapsed = collapsed;

            return this;
        }

        internal override string StartTag
        {
            get
            {
                return base.StartTag + "<ul class=\"nav nav-list\">";
            }
        }

        internal override string EndTag
        {
            get
            {
                return "</ul>" + base.EndTag;
            }
        }
    }
}
