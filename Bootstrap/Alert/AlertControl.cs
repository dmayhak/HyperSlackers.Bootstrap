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
	public class AlertControl<TModel> : ControlBase<AlertControl<TModel>, TModel>
	{
        internal string alertHtml;
        internal bool isDismissible;
        internal AlertStyle alertStyle = AlertStyle.Danger;

		internal AlertControl(HtmlHelper<TModel> html, string alertHtml)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!alertHtml.IsNullOrWhiteSpace());

			this.alertHtml = alertHtml;
			this.isDismissible = false;

            this.controlHtmlAttributes.AddClass("alert");
            this.controlHtmlAttributes.AddClass(Helpers.GetCssClass(alertStyle));
		}

        public AlertControl<TModel> Dismissible()
		{
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

			this.isDismissible = true;

			return this;
		}

        public AlertControl<TModel> Style(AlertStyle style)
        {
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.controlHtmlAttributes.RemoveClass(Helpers.GetCssClass(alertStyle));
            this.alertStyle = style;
            this.controlHtmlAttributes.AddClass(Helpers.GetCssClass(alertStyle));

            return this;
        }

        public AlertControl<TModel> IsLongMessage()
		{
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.controlHtmlAttributes.AddClass("alert-block");

			return this;
		}

		protected override string Render()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = this.controlHtmlAttributes.FormatHtmlAttributes();

			TagBuilder tagBuilder = new TagBuilder("div");

			tagBuilder.MergeHtmlAttributes(attributes);

            if (this.isDismissible)
            {
                tagBuilder.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + this.alertHtml;
            }
            else
            {
                tagBuilder.InnerHtml = this.alertHtml;
            }

			return tagBuilder.ToString(TagRenderMode.Normal);
		}
	}
}