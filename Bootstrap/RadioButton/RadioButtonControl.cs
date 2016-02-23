using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using HyperSlackers.Bootstrap.Core;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class RadioButtonControl<TModel> : InputControlBase<RadioButtonControl<TModel>, TModel>
	{
        internal bool isChecked;

		internal RadioButtonControl(HtmlHelper<TModel> html, string htmlFieldName, object value, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            selectedValue = value;
		}

        public RadioButtonControl<TModel> IsChecked(bool isChecked)
        {
            Contract.Ensures(Contract.Result<RadioButtonControl<TModel>>() != null);

            this.isChecked = isChecked;

            return (RadioButtonControl<TModel>)this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            SetDefaultTooltip();
            if (tooltip != null)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

            if (!id.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", id);
            }

            string validationHtml = RenderValidationMessage();

            return string.Concat(html.RadioButton(htmlFieldName, selectedValue, isChecked, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), validationHtml);
        }

        protected override string RenderLabeledControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            if (controlHtmlAttributes.Keys.Contains("id"))
            {
                labelTagBuilder.Attributes["for"] = controlHtmlAttributes["id"].ToString();
            }

            string htmlString = MvcHtmlString.Create(ToHtmlString()).ToHtmlString();

            SetLabelText();
            if (labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = htmlString;
            }
            else
            {
                labelTagBuilder.InnerHtml = htmlString + labelText + GetRequiredStarTagBuilder().ToString();
            }

            return MvcHtmlString.Create("<div class=\"radio\">{0}</div>".FormatWith(labelTagBuilder.ToString(TagRenderMode.Normal))).ToHtmlString();
        }

        protected override string RenderFormGroupControl(string controlHtml, string labelHtml, string validationMessage, bool fieldIsValid = true)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder controlTagBuilder = new TagBuilder("div");
            controlTagBuilder.MergeHtmlAttributes(formGroup.formGroupHtmlAttributes.FormatHtmlAttributes());
            controlTagBuilder.AddOrMergeCssClass("form-group");

            controlTagBuilder.AddOrMergeCssClass((string)Helpers.GetCssClass(html, formGroup.size).Replace("input", "form-group"));

            if (!fieldIsValid)
            {
                controlTagBuilder.AddCssClass("has-error");
            }

            controlTagBuilder.AddCssClass(GetFormGroupControlCssClass());

            string formatString = "{0}";

            if (formGroup.formType == FormType.Horizontal)
            {
                TagBuilder horizontalFormControlTagBuilder = new TagBuilder("div");
                horizontalFormControlTagBuilder.MergeAttributes<string, object>(formGroup.controlHtmlAttributes);
                horizontalFormControlTagBuilder.AddCssClass(GetHorizontalFromGroupControlCssClass());
                horizontalFormControlTagBuilder.AddCssClass(Helpers.CssColClassOffset(labelWidthXs, labelWidthSm, labelWidthMd, labelWidthLg));
                horizontalFormControlTagBuilder.SetInnerText(formatString);
                formatString = horizontalFormControlTagBuilder.ToString();
            }

            controlTagBuilder.InnerHtml = formatString.FormatWith(labelHtml);

            return controlTagBuilder.ToString();
        }
	}
}