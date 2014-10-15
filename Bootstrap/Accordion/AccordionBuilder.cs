using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class AccordionBuilder<TModel> : DisposableHtmlElement<TModel, Accordion>
	{
        // TODO: make accordion expand/collapse via clicking the whole header?
        internal int panelCount;
        private bool disposed;

		internal AccordionBuilder(HtmlHelper<TModel> html, Accordion accordion) 
            : base(html, accordion)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(accordion != null, "accordion");

            this.textWriter.Write(this.element.StartTag);
		}

        public AccordionPanelBuilder<TModel> BeginPanel(string title)
		{
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AccordionPanelBuilder<TModel>>() != null);

            AccordionPanel panel = new AccordionPanel(title);

            return BeginPanel(panel);
        }

        public AccordionPanelBuilder<TModel> BeginPanel(string title, PanelStyle style)
        {
            Contract.Requires<ArgumentException>(!title.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AccordionPanelBuilder<TModel>>() != null);

            AccordionPanel panel = new AccordionPanel(title).Style(style);

            return BeginPanel(panel);
        }

        public AccordionPanelBuilder<TModel> BeginPanel(AccordionPanel panel)
        {
            Contract.Requires<ArgumentNullException>(panel != null, "panel");
            Contract.Ensures(Contract.Result<AccordionPanelBuilder<TModel>>() != null);

            panelCount++;

            panel.parentAccordionId = this.element.id;

            if (panel.panelId.IsNullOrWhiteSpace())
            {
                panel.panelId = this.element.id + "-" + this.panelCount.ToString();
            }

            if (!panel.isActivePanel.HasValue)
            {
                panel.isActivePanel = panelCount == this.element.activePanel;
            }

            if (!panel.style.HasValue)
            {
                panel.style = this.element.style;
            }

            return new AccordionPanelBuilder<TModel>(this.textWriter, panel);
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //this.textWriter.Write(string.Empty);

                    this.disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}