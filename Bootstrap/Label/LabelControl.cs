using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class LabelControl<TModel> : ControlBase<LabelControl<TModel>, TModel>
	{
        internal string text;
        internal LabelStyle style = LabelStyle.Default;
        internal bool displayInlineBlock;

		internal LabelControl(HtmlHelper<TModel> html, string text)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

			this.text = text;
        }

        public LabelControl<TModel> Style(LabelStyle style)
        {
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

            this.style = style;

            return this;
        }

        public LabelControl<TModel> DisplayInlineBlock(bool displayInlineBlock)
		{
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

			this.displayInlineBlock = displayInlineBlock;

            return this;
		}

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder labelTagBuilder = new TagBuilder("span");

            labelTagBuilder.MergeHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());
            labelTagBuilder.AddCssClass("label");
            labelTagBuilder.AddCssClass(Helpers.GetCssClass(style));
            labelTagBuilder.AddCssStyle("display", "inline-block");

            labelTagBuilder.InnerHtml = text;

            return MvcHtmlString.Create(labelTagBuilder.ToString(TagRenderMode.Normal)).ToHtmlString();
		}
	}
}