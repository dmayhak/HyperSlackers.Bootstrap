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
        internal Icon icon;

        internal AlertControl(HtmlHelper<TModel> html, string alertHtml)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!alertHtml.IsNullOrWhiteSpace());

			this.alertHtml = alertHtml;
			isDismissible = false;

            controlHtmlAttributes.AddIfNotExistsCssClass("alert");
            controlHtmlAttributes.AddIfNotExistsCssClass(Helpers.GetCssClass(alertStyle));
		}

        public AlertControl<TModel> Dismissible()
		{
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

			isDismissible = true;

			return this;
		}

        public AlertControl<TModel> Style(AlertStyle style)
        {
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            controlHtmlAttributes.RemoveCssClass(Helpers.GetCssClass(alertStyle));
            alertStyle = style;
            controlHtmlAttributes.AddIfNotExistsCssClass(Helpers.GetCssClass(alertStyle));

            return this;
        }

        public AlertControl<TModel> IsLongMessage()
		{
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            controlHtmlAttributes.AddIfNotExistsCssClass("alert-block");

			return this;
        }

        public AlertControl<TModel> Icon(GlyphIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.icon = icon;

            return this;
        }

        public AlertControl<TModel> Icon(GlyphIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.icon = new GlyphIcon(icon, isWhite);

            return this;
        }

        public AlertControl<TModel> Icon(FontAwesomeIcon icon)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.icon = icon;

            return this;
        }

        public AlertControl<TModel> Icon(FontAwesomeIconType icon, bool isWhite = false)
        {
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            this.icon = new FontAwesomeIcon(icon, isWhite);

            return this;
        }

        public AlertControl<TModel> Icon(string cssClass)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            icon = new GlyphIcon(cssClass);

            return this;
        }

        protected override string Render()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes();

			TagBuilder tagBuilder = new TagBuilder("div");

			tagBuilder.MergeHtmlAttributes(attributes);

            string prepend = string.Empty;
            if (icon != null)
            {
                prepend = icon.ToHtmlString() + " ";
            }

            if (isDismissible)
            {
                tagBuilder.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + prepend + alertHtml;
            }
            else
            {
                tagBuilder.InnerHtml = prepend + alertHtml;
            }

			return tagBuilder.ToString(TagRenderMode.Normal);
		}
	}
}