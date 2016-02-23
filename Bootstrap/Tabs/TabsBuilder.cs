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

            textWriter.Write(element.StartTag);

            activeTabIndex = element.activeTabIndex;

            StringBuilder startTag = new StringBuilder();
            startTag.Append("<ul class=\"nav");
            switch (element.navType)
            {
                case NavType.Pills:
                    startTag.Append(" nav-pills");
                    break;
                case NavType.Tabs:
                default:
                    startTag.Append(" nav-tabs");
                    break;
            }
            if (element.justified)
            {
                startTag.Append(" nav-justified");
            }
            startTag.Append("\">");

            textWriter.Write(startTag.ToString());
		}

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)  // TODO: do we need this???
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(html, dropDown, "li", new { @class = "dropdown" }, true);
        }

        public TabsPanel BeginPanel()
		{
            Contract.Ensures(Contract.Result<TabsPanel>() != null);

            panelIndex++;

            if (!isHeaderClosed)
            {
                textWriter.Write("</ul>");
                isHeaderClosed = true;
            }

            string tabId = tabIds.Dequeue();
            if (panelIndex != 1)
            {
                return new TabsPanel(textWriter, "div", tabId, panelIndex == activeTabIndex);
            }
            textWriter.Write("<div class=\"tab-content\">");
            isFirstTab = false;

            return new TabsPanel(textWriter, "div", tabId, panelIndex == activeTabIndex);
		}

        public TabControl<TModel> Tab(string label)
		{
            Contract.Requires<ArgumentException>(!label.IsNullOrWhiteSpace());

            TabControl<TModel> tabsTab;
            string tabId = element.id + "-" + tabIndex;
            tabIds.Enqueue(tabId);
            if (!isFirstTab)
            {
                tabsTab = new TabControl<TModel>(html, label, tabId, tabIndex == activeTabIndex);
            }
            else
            {
                if (activeTabIndex == 0)
                {
                    activeTabIndex = 1;
                }
                tabsTab = new TabControl<TModel>(html, label, tabId, tabIndex == activeTabIndex);
                isFirstTab = false;
            }

            tabIndex++;

            return tabsTab;
		}

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div>");

                    disposed = true;
                }
            }

            base.Dispose(disposing);
        }
	}
}