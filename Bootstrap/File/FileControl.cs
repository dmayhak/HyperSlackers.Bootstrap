using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Core;
using System.Collections.Generic;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class FileControl<TModel> : InputControlBase<FileControl<TModel>, TModel>
	{
		internal FileControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
		}

        public FileControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<FileControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public FileControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FileControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public FileControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<FileControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

            SetDefaultTooltip();
            if (tooltip != null)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes().AddOrReplaceHtmlAttribute("type", "File");

            if (!id.IsNullOrWhiteSpace())
            {
                attributes.AddOrReplaceHtmlAttribute("id", id);
            }

            string helpText = string.Empty;
            if (this.helpText != null)
            {
                helpText = this.helpText.ToHtmlString();
            }

            string validationText = string.Empty;
            if (!showValidationMessageInline)
            {
                validationText = RenderValidationMessage();
            }

            return formatString.FormatWith(html.TextBox(htmlFieldName, null, attributes).ToHtmlString(), helpText, validationText);
        }
	}
}