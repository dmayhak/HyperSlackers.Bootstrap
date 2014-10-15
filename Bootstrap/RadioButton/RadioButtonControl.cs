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

            this.value = value;
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
            if (this.tooltip != null)
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

            if (!this.id.IsNullOrWhiteSpace())
            {
                this.controlHtmlAttributes.AddOrReplace("id", this.id);
            }

            string validationHtml = this.RenderValidationMessage();

            return string.Concat(html.RadioButton(this.htmlFieldName, this.value, this.isChecked, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), validationHtml);
        }

        protected override string RenderLabeledControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(this.htmlFieldName);

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            if (this.controlHtmlAttributes.Keys.Contains("id"))
            {
                labelTagBuilder.Attributes["for"] = this.controlHtmlAttributes["id"].ToString();
            }

            string htmlString = MvcHtmlString.Create(this.ToHtmlString()).ToHtmlString();

            SetLabelText();
            if (this.labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = htmlString;
            }
            else
            {
                labelTagBuilder.InnerHtml = htmlString + this.labelText + GetRequiredStarTagBuilder().ToString();
            }

            return MvcHtmlString.Create("<div class=\"radio\">{0}</div>".FormatWith(labelTagBuilder.ToString(TagRenderMode.Normal))).ToHtmlString();
        }

        protected override string RenderFormGroupControl(string controlHtml, string labelHtml, string validationMessage, bool fieldIsValid = true)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder controlTagBuilder = new TagBuilder("div");
            controlTagBuilder.MergeHtmlAttributes(this.formGroup.formGroupHtmlAttributes.FormatHtmlAttributes());
            controlTagBuilder.AddOrMergeCssClass("form-group");

            if (!fieldIsValid)
            {
                controlTagBuilder.AddCssClass("has-error");
            }

            controlTagBuilder.AddCssClass(GetFormGroupControlCssClass());

            string formatString = "{0}";

            if (this.formGroup.formType == FormType.Horizontal)
            {
                TagBuilder horizontalFormControlTagBuilder = new TagBuilder("div");
                horizontalFormControlTagBuilder.MergeAttributes<string, object>(this.formGroup.controlHtmlAttributes);
                horizontalFormControlTagBuilder.AddCssClass(GetHorizontalFromGroupControlCssClass());
                horizontalFormControlTagBuilder.AddCssClass(Helpers.CssColClassOffset(this.labelWidthXs, this.labelWidthSm, this.labelWidthMd, this.labelWidthLg));
                horizontalFormControlTagBuilder.SetInnerText(formatString);
                formatString = horizontalFormControlTagBuilder.ToString();
            }

            controlTagBuilder.InnerHtml = formatString.FormatWith(labelHtml);

            return controlTagBuilder.ToString();
        }
	}
}