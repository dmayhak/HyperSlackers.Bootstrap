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
	public class DropDownMenuButtonControl<TModel> : ControlBase<DropDownMenuButtonControl<TModel>, TModel>
	{
        internal List<DropDownMenuItemControl<TModel>> menuItems = new List<DropDownMenuItemControl<TModel>>();
		internal DropDownAlignment alignToDirection = DropDownAlignment.Left;
		internal int? maxHeight;
        internal DropDown dropdown;

		internal DropDownMenuButtonControl(HtmlHelper<TModel> html, DropDown dropdown)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.dropdown = dropdown;
		}

        public DropDownMenuButtonControl<TModel> AlignTo(DropDownAlignment direction)
		{
            Contract.Ensures(Contract.Result<DropDownMenuButtonControl<TModel>>() != null);

            alignToDirection = direction;

			return this;
		}

        public DropDownMenuButtonControl<TModel> MaxHeight(int heightInPixels)
		{
            Contract.Requires<ArgumentOutOfRangeException>(heightInPixels > 0);
            Contract.Ensures(Contract.Result<DropDownMenuButtonControl<TModel>>() != null);

            maxHeight = new int?(heightInPixels);

			return this;
		}

        public DropDownMenuButtonControl<TModel> MenuItems(Action<DropDownMenuBuilder<TModel>> dropDownMenuBuilder)
		{
            Contract.Requires<ArgumentNullException>(dropDownMenuBuilder != null, "dropDownMenuBuilder");
            Contract.Ensures(Contract.Result<DropDownMenuButtonControl<TModel>>() != null);

            DropDownMenuBuilder<TModel> dropDownMenuBuilders = new DropDownMenuBuilder<TModel>(html);
			dropDownMenuBuilder(dropDownMenuBuilders);

            foreach (DropDownMenuItemControl<TModel> bootstrapDropDownMenuItem in dropDownMenuBuilders)
			{
                menuItems.Add(bootstrapDropDownMenuItem);
			}

			return this;
		}

		protected override string RenderControl()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder buttonTagBuilder = new TagBuilder("button");
            buttonTagBuilder.AddCssClass(Helpers.GetCssClass(dropdown.buttonSize));
            buttonTagBuilder.AddCssClass(Helpers.GetCssClass(html, dropdown.buttonStyle));
            buttonTagBuilder.AddCssClass("btn dropdown-toggle");
            buttonTagBuilder.AddOrMergeAttribute("data-toggle", "dropdown");

            buttonTagBuilder.InnerHtml = dropdown.actionText + " <span class=\"caret\"></span>";

            TagBuilder menuTagBuilder = new TagBuilder("ul");

			menuTagBuilder.MergeHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());

			if (maxHeight.HasValue)
			{
				menuTagBuilder.AddCssStyle("max-height", string.Concat(maxHeight.ToString(), "px"));
				menuTagBuilder.AddCssStyle("overflow-y", "scroll");
			}

			menuTagBuilder.AddCssClass("dropdown-menu");

			if (alignToDirection == DropDownAlignment.Right)
			{
				menuTagBuilder.AddCssClass("pull-right");
			}

            foreach (var item in menuItems)
            {
                menuTagBuilder.InnerHtml += item.ToHtmlString();
            }

			return "<div class=\"input-group-btn\">{0}{1}</div>".FormatWith(buttonTagBuilder.ToString(TagRenderMode.Normal), menuTagBuilder.ToString(TagRenderMode.Normal));
		}
	}
}