using System;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Tabs : HtmlElement
	{
        internal int activeTabIndex;
        internal bool justified;
        internal NavType navType = NavType.Tabs;

		public Tabs(string id) 
            : base("div")
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

			this.id = id;
            AddClass("tabbable");
            AddOrReplaceHtmlAttribute("id", id);
		}

		public Tabs ActiveTab(int activeTabIndex)
		{
            Contract.Requires<ArgumentOutOfRangeException>(activeTabIndex >= 0);
            Contract.Ensures(Contract.Result<Tabs>() != null);

			this.activeTabIndex = activeTabIndex;

			return this;
		}

        public Tabs Justified()
        {
            justified = true;

            return this;
        }

        public Tabs Style(NavType type)
        {
            Contract.Ensures(Contract.Result<Tabs>() != null);

            navType = type;

            return this;
        }
	}
}