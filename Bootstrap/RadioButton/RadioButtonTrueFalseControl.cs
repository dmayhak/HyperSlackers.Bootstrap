using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Core;
using System.Collections.Generic;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class RadioButtonTrueFalseControl<TModel> : ControlListBase<RadioButtonTrueFalseControl<TModel>, TModel>
	{
        internal object inputTrueValue = true;
        internal object inputFalseValue = false;
        internal string labelTrueText = "Yes";
        internal string labelFalseText = "No";
        internal bool? selectedValue;
        internal IDictionary<string, object> htmlAttributesInputTrue = new Dictionary<string, object>();
        internal IDictionary<string, object> htmlAttributesInputFalse = new Dictionary<string, object>();
        internal IDictionary<string, object> htmlAttributesLabelTrue = new Dictionary<string, object>();
        internal IDictionary<string, object> htmlAttributesLabelFalse = new Dictionary<string, object>();

		public RadioButtonTrueFalseControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
		}

        public RadioButtonTrueFalseControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());
            
            return this;
        }

        public RadioButtonTrueFalseControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);
            
            return this;
        }

        public RadioButtonTrueFalseControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());
            
            return this;
        }

        public override RadioButtonTrueFalseControl<TModel> Disabled(bool isDisabled = true)
        {
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            if (isDisabled)
            {
                htmlAttributesInputTrue.AddOrReplaceHtmlAttribute("disabled", "disabled");
                htmlAttributesInputFalse.AddOrReplaceHtmlAttribute("disabled", "disabled");
            }
            else
            {
                htmlAttributesInputTrue.Remove("disabled");
                htmlAttributesInputFalse.Remove("disabled");
            }

            return this;
        }

        public RadioButtonTrueFalseControl<TModel> HtmlAttributesInputFalse(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            htmlAttributesInputFalse = htmlAttributes.ToDictionary();

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> HtmlAttributesInputTrue(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            htmlAttributesInputTrue = htmlAttributes.ToDictionary();

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> HtmlAttributesLabelFalse(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            htmlAttributesLabelFalse = htmlAttributes.ToDictionary();

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> HtmlAttributesLabelTrue(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            htmlAttributesLabelTrue = htmlAttributes.ToDictionary();

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> ControlLabelText(string trueText, string falseText)
        {
            Contract.Requires<ArgumentException>(!trueText.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!falseText.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            labelTrueText = trueText;
            labelFalseText = falseText;

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> ControlValues(object trueValue, object falseValue)
        {
            Contract.Requires<ArgumentNullException>(trueValue != null, "trueValue");
            Contract.Requires<ArgumentNullException>(falseValue != null, "falseValue");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            inputTrueValue = trueValue;
            inputFalseValue = falseValue;

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public override RadioButtonTrueFalseControl<TModel> Readonly(bool isReadonly = true)
        {
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            if (isReadonly)
            {
                htmlAttributesInputTrue.AddOrReplaceHtmlAttribute("readonly", "readonly");
                htmlAttributesInputFalse.AddOrReplaceHtmlAttribute("readonly", "readonly");
            }
            else
            {
                htmlAttributesInputTrue.Remove("readonly");
                htmlAttributesInputFalse.Remove("readonly");
            }

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> Tooltip()
        {
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            SetDefaultTooltip();

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            this.tooltip = tooltip;

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            tooltip = new Tooltip(text);

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            tooltip = new Tooltip(html);

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        public RadioButtonTrueFalseControl<TModel> SelectedValue(bool? value)
        {
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            selectedValue = value;

            return (RadioButtonTrueFalseControl<TModel>)this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("container-radio-true-false"); // TODO: is this a bootstrap thing?
            tagBuilder.AddCssStyle("display", "inline-block");

            SetDefaultTooltip();
            if (tooltip != null)
            {
                tagBuilder.MergeHtmlAttributes(tooltip.ToDictionary());
            }

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            bool isTrue = false;
            bool isFalse = false;
            if (metadata.Model != null)
            {
                isTrue = inputTrueValue.ToString() == metadata.Model.ToString();
                isFalse = inputTrueValue.ToString() != metadata.Model.ToString();
            }

            RadioButtonControl<TModel> trueRadioButton = new RadioButtonControl<TModel>(html, htmlFieldName, inputTrueValue, metadata);
            trueRadioButton.IsChecked(isTrue);
            trueRadioButton.ControlHtmlAttributes(htmlAttributesInputTrue.AddOrReplaceHtmlAttribute("id", string.Concat(fullHtmlFieldName.FormatForMvcInputId(), "_t")));
            trueRadioButton.Label(labelTrueText);
            trueRadioButton.ShowRequiredStar(false);
            trueRadioButton.LabelHtmlAttributes(htmlAttributesLabelTrue);

            RadioButtonControl<TModel> falseRadioButton = new RadioButtonControl<TModel>(html, htmlFieldName, inputFalseValue, metadata);
            falseRadioButton.IsChecked(isFalse);
            falseRadioButton.ControlHtmlAttributes(htmlAttributesInputFalse.AddOrReplaceHtmlAttribute("id", string.Concat(fullHtmlFieldName.FormatForMvcInputId(), "_f")));
            falseRadioButton.Label(labelFalseText);
            falseRadioButton.ShowRequiredStar(false);
            falseRadioButton.LabelHtmlAttributes(htmlAttributesLabelFalse);

            string labelHtmlTrue = trueRadioButton.ToHtmlString(); 
            string labelHtmlFalse = falseRadioButton.ToHtmlString(); 
            string helpHtml = (helpText != null ? helpText.ToHtmlString() : string.Empty);
            string validationHtml = (showValidationMessageInline ? string.Empty : RenderValidationMessage());

            tagBuilder.InnerHtml = labelHtmlTrue + labelHtmlFalse;

            return string.Format(formatString, tagBuilder, helpHtml, validationHtml);
        }
	}
}