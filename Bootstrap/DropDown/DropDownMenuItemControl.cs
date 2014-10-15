using HyperSlackers.Bootstrap.Core;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DropDownMenuItemControl<TModel> : ControlBase<DropDownMenuItemControl<TModel>, TModel>
	{
		internal MvcHtmlString menuItem;
        internal DropDownMenuControl<TModel> dropDownMenu;
		internal bool isDivider;
		internal bool active;

        internal DropDownMenuItemControl(HtmlHelper<TModel> html, MvcHtmlString actionLink)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(actionLink != null, "actionLink");

			this.menuItem = actionLink;
		}

        internal DropDownMenuItemControl(HtmlHelper<TModel> html, string link)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!link.IsNullOrWhiteSpace());

			this.menuItem = MvcHtmlString.Create(link);
		}

        internal DropDownMenuItemControl(HtmlHelper<TModel> html, bool isDivider)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

			this.isDivider = isDivider;
		}

		public DropDownMenuItemControl<TModel> Active(bool active)
		{
            Contract.Ensures(Contract.Result<DropDownMenuItemControl<TModel>>() != null);

			this.active = active;

			return this;
		}

        public DropDownMenuControl<TModel> DropDownMenu()
		{
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

            this.dropDownMenu = new DropDownMenuControl<TModel>(this.html);

			return this.dropDownMenu;
		}

		protected override string RenderControl()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			if (this.isDivider)
			{
				return "<li class=\"divider\"></li>";
			}
			string str = this.menuItem.ToHtmlString().Replace("<a", "<a tabindex=\"-1\"");
			string str1 = (this.dropDownMenu != null ? this.dropDownMenu.ToHtmlString() : string.Empty);
			string str2 = (this.dropDownMenu != null ? " class=\"dropdown-submenu\"" : string.Empty);
			object[] objArray = new object[] { str, str1, str2, (this.active ? " class=\"active\"" : string.Empty) };
			return string.Format("<li{2}{3}>{0}{1}</li>", objArray);
		}
	}
}