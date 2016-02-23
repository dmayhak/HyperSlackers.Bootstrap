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
    public class CkEditorControl<TModel> : InputControlBase<CkEditorControl<TModel>, TModel>
	{
        internal int rows;
        internal int columns;

        internal CkEditorControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            if (metadata.Model != null)
            {
                selectedValue = metadata.Model.ToString();
            }
            else
            {
                selectedValue = null;
            }
		}

        public CkEditorControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public CkEditorControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public CkEditorControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public CkEditorControl<TModel> Columns(int columns)
        {
            Contract.Requires<ArgumentOutOfRangeException>(columns > 0);
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            this.columns = columns;

            return this;
        }

        public CkEditorControl<TModel> Rows(int rows)
        {
            Contract.Requires<ArgumentOutOfRangeException>(rows > 0);
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            this.rows = rows;

            return this;
        }

        public CkEditorControl<TModel> Value(string value)
        {
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            selectedValue = value;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

            if (!id.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", id);
            }

            controlHtmlAttributes.AddIfNotExistsCssClass("ckeditor");
            controlHtmlAttributes.AddIfNotExistsCssClass("form-control");

            SetDefaultTooltip();
            if (tooltip != null)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            string helpHtml = (helpText != null ? helpText.ToHtmlString() : string.Empty);
            string validationHtml = (showValidationMessageInline ? string.Empty : RenderValidationMessage());

            return string.Format(formatString, html.TextArea(htmlFieldName, (selectedValue ?? string.Empty).ToString(), rows, columns, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), helpHtml, validationHtml);
        }
	}
}