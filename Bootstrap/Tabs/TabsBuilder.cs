using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TabsBuilder<TModel> : DisposableHtmlElement<TModel, Tabs>
	{
		internal int tabIndex = 1;
		internal int panelIndex;
		internal readonly Queue<string> tabIds = new Queue<string>();
		internal bool isFirstTab = true;
		internal int activeTabIndex;
		internal bool isHeaderClosed;
        private bool disposed;

        internal TabsBuilder(HtmlHelper<TModel> html, Tabs tabs) 
            : base(html, tabs)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tabs != null, "tabs");

            this.textWriter.Write(this.element.StartTag);

			this.activeTabIndex = this.element.activeTabIndex;

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<ul class=\"nav");
            switch (this.element.navType)
            {
                case NavType.Pills:
                    startTag.Append(" nav-pills");
                    break;
                case NavType.Tabs:
                default:
                    startTag.Append(" nav-tabs");
                    break;
            }
            if (this.element.justified)
            {
                startTag.Append(" nav-justified");
            }
            startTag.Append("\">");

            this.textWriter.Write(startTag.ToString());
		}

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)  // TODO: do we need this???
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(this.html, dropDown, "li", new { @class = "dropdown" }, true);
        }

        public TabsPanel BeginPanel()
		{
            Contract.Ensures(Contract.Result<TabsPanel>() != null);

            this.panelIndex++;

            if (!this.isHeaderClosed)
            {
                this.textWriter.Write("</ul>");
                this.isHeaderClosed = true;
            }

            string tabId = this.tabIds.Dequeue();
            if (this.panelIndex != 1)
            {
                return new TabsPanel(this.textWriter, "div", tabId, this.panelIndex == this.activeTabIndex);
            }
            this.textWriter.Write("<div class=\"tab-content\">");
            this.isFirstTab = false;

            return new TabsPanel(this.textWriter, "div", tabId, this.panelIndex == this.activeTabIndex);
		}

        public TabControl<TModel> Tab(string label)
		{
            Contract.Requires<ArgumentException>(!label.IsNullOrWhiteSpace());

            TabControl<TModel> tabsTab;
            string tabId = this.element.id + "-" + this.tabIndex;
            this.tabIds.Enqueue(tabId);
            if (!this.isFirstTab)
            {
                tabsTab = new TabControl<TModel>(this.html, label, tabId, this.tabIndex == this.activeTabIndex);
            }
            else
            {
                if (this.activeTabIndex == 0)
                {
                    this.activeTabIndex = 1;
                }
                tabsTab = new TabControl<TModel>(this.html, label, tabId, this.tabIndex == this.activeTabIndex);
                this.isFirstTab = false;
            }

            this.tabIndex++;

            return tabsTab;
		}

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.textWriter.Write("</div>");

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}