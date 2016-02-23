using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class HelpTextControl<TModel> : ControlBase<HelpTextControl<TModel>, TModel>
	{
		internal string text;

		internal HelpTextControl(HtmlHelper<TModel> html, string text)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());

			this.text = text;
		}

		protected override string RenderControl()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

			TagBuilder tagBuilder = new TagBuilder("span");
		    tagBuilder.AddCssClass("help-block");
			tagBuilder.InnerHtml = text;
			
            return tagBuilder.ToString();
		}
	}
}