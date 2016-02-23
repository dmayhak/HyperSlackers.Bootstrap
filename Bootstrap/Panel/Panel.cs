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
    public class Panel : HtmlElement<Panel>
	{
        internal PanelStyle style = PanelStyle.Default;
        internal bool collapsible;
        internal bool collapsed;

		public Panel(string id)
            : base("div")
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            AddClass("panel");
            this.id = id;
            //this.AddOrMergeHtmlAttribute("id", this.id);
        }

        public Panel Style(PanelStyle style)
		{
            Contract.Ensures(Contract.Result<Panel>() != null);

            this.style = style;

			return this;
		}

        public Panel Collapsible(bool collapsible = true)
		{
            Contract.Ensures(Contract.Result<Panel>() != null);

            this.collapsible = collapsible;

			return this;
		}

        public Panel Collapsed(bool collapsed = true)
        {
            Contract.Ensures(Contract.Result<Panel>() != null);

            this.collapsed = collapsed;

            return this;
        }
	}
}