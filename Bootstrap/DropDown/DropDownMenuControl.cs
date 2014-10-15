using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class DropDownMenuControl<TModel> : ControlBase<DropDownMenuControl<TModel>, TModel>
	{
        internal List<DropDownMenuItemControl<TModel>> menuItems = new List<DropDownMenuItemControl<TModel>>();
		internal DropDownAlignment alignToDirection = DropDownAlignment.Left;
		internal int? maxHeight;

		internal DropDownMenuControl(HtmlHelper<TModel> html)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
		}

        public DropDownMenuControl<TModel> AlignTo(DropDownAlignment direction)
		{
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

			this.alignToDirection = direction;

			return this;
		}

        public DropDownMenuControl<TModel> MaxHeight(int heightInPixels)
		{
            Contract.Requires<ArgumentOutOfRangeException>(heightInPixels > 0);
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

			this.maxHeight = new int?(heightInPixels);

			return this;
		}

        public DropDownMenuControl<TModel> MenuItems(Action<DropDownMenuBuilder<TModel>> dropDownMenuBuilder)
		{
            Contract.Requires<ArgumentNullException>(dropDownMenuBuilder != null, "dropDownMenuBuilder");
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

            DropDownMenuBuilder<TModel> dropDownMenuBuilders = new DropDownMenuBuilder<TModel>(this.html);
			dropDownMenuBuilder(dropDownMenuBuilders);

            foreach (DropDownMenuItemControl<TModel> bootstrapDropDownMenuItem in dropDownMenuBuilders)
			{
				this.menuItems.Add(bootstrapDropDownMenuItem);
			}

			return this;
		}

		protected override string RenderControl()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			TagBuilder menuTagBuilder = new TagBuilder("ul");

			menuTagBuilder.MergeHtmlAttributes(this.controlHtmlAttributes.FormatHtmlAttributes());

			if (this.maxHeight.HasValue)
			{
				menuTagBuilder.AddCssStyle("max-height", string.Concat(this.maxHeight.ToString(), "px"));
				menuTagBuilder.AddCssStyle("overflow-y", "scroll");
			}

			menuTagBuilder.AddCssClass("dropdown-menu");

			if (this.alignToDirection == DropDownAlignment.Right)
			{
				menuTagBuilder.AddCssClass("pull-right");
			}

            foreach (var item in this.menuItems)
            {
                menuTagBuilder.InnerHtml += item.ToHtmlString();
            }

			return menuTagBuilder.ToString(TagRenderMode.Normal);
		}
	}
}