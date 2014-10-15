using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class AccordionPanel
	{
        readonly internal string title;
        internal string panelId;
        internal string parentAccordionId;
        internal bool? isActivePanel;
        internal PanelStyle? style;

		public AccordionPanel(string title)
		{
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());

            this.title = title;
		}

        public AccordionPanel Style(PanelStyle style)
        {
            Contract.Ensures(Contract.Result<AccordionPanel>() != null);

            this.style = style;

            return this;
        }

        public AccordionPanel Id(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AccordionPanel>() != null);

            this.panelId = id;

            return this;
        }

        public AccordionPanel Active(bool isActivePanel = true)
        {
            Contract.Ensures(Contract.Result<AccordionPanel>() != null);

            this.isActivePanel = isActivePanel;

            return this;
        }
	}
}