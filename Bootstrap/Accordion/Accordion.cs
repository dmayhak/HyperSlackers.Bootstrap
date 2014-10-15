using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Accordion : HtmlElement<Accordion>
	{
        internal int? activePanel;
        internal PanelStyle style = PanelStyle.Default;

		public Accordion(string id) 
            : base("div")
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

			this.id = HtmlHelper.GenerateIdFromName(id);
            this.AddClass("panel-group");
            this.AddOrMergeHtmlAttribute("id", this.id, true);
		}

        public Accordion Style(PanelStyle style)
        {
            Contract.Ensures(Contract.Result<Accordion>() != null);

            this.style = style;

            return this;
        }

		public Accordion ActivePanel(int panelNumber)
		{
            Contract.Requires<ArgumentOutOfRangeException>(panelNumber >= 0);
            Contract.Ensures(Contract.Result<Accordion>() != null);

			this.activePanel = new int?(panelNumber);

			return this;
		}
	}
}