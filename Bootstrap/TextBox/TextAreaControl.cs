using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using System.Collections.Generic;
using HyperSlackers.Bootstrap.Core;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TextAreaControl<TModel> : InputControlBase<TextAreaControl<TModel>, TModel>
	{
        internal int rows;
        internal int columns;

		internal TextAreaControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            if (metadata.Model != null)
            {
                this.value = metadata.Model.ToString();
            }
            else
            {
                this.value = null;
            }
		}

        public TextAreaControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, GetHelpTextText());

            return this;
        }

        public TextAreaControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, text);

            return this;
        }

        public TextAreaControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public TextAreaControl<TModel> Columns(int columns)
        {
            Contract.Requires<ArgumentOutOfRangeException>(columns > 0);
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.columns = columns;

            return this;
        }

        public TextAreaControl<TModel> Rows(int rows)
        {
            Contract.Requires<ArgumentOutOfRangeException>(rows > 0);
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.rows = rows;

            return this;
        }

        public TextAreaControl<TModel> Value(string value)
        {
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            this.value = value;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

            if (!this.id.IsNullOrWhiteSpace())
            {
                this.controlHtmlAttributes.AddOrReplace("id", this.id);
            }

            this.controlHtmlAttributes.AddClass("form-control");

            SetDefaultTooltip();
            if (this.tooltip != null)
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            string helpHtml = (this.helpText != null ? this.helpText.ToHtmlString() : string.Empty);
            string validationHtml = (showValidationMessageInline ? string.Empty : this.RenderValidationMessage());

            return string.Format(formatString, html.TextArea(this.htmlFieldName, (this.value ?? string.Empty).ToString(), this.rows, this.columns, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), helpHtml, validationHtml);
        }
	}
}