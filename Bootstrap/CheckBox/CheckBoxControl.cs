using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class CheckBoxControl<TModel> : InputControlBase<CheckBoxControl<TModel>, TModel>
	{
        internal bool isChecked;
        internal bool isSingleInput;

        internal CheckBoxControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.isChecked = (metadata.Model == null ? false : (metadata.Model.GetType() == typeof(bool) ? (bool)metadata.Model : false));
		}

        internal CheckBoxControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, object value, bool isSingleInput)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            //x Contract.Requires<ArgumentNullException>(value != null, "value"); 

            this.isChecked = (metadata.Model == null ? false : (metadata.Model.GetType() == typeof(bool) ? (bool)metadata.Model : false));
            this.value = value;
            this.isSingleInput = isSingleInput;
		}

        public CheckBoxControl<TModel> IsChecked(bool isChecked)
        {
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

            this.isChecked = isChecked;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (!this.isSingleInput) // TODO: what does this flag really mean?
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

                SetDefaultTooltip();
                if (this.tooltip != null)
                {
                    this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
                }

                if (!this.id.IsNullOrWhiteSpace())
                {
                    this.controlHtmlAttributes.AddOrReplace("id", this.id);
                }

                string validationHtml = this.RenderValidationMessage();

                return string.Concat(html.CheckBox(this.htmlFieldName, this.isChecked, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), validationHtml);
            }
            else
            {
                ModelState modelState = null;
                string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(this.htmlFieldName);

                this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

                SetDefaultTooltip();
                if (this.tooltip != null)
                {
                    this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
                }

                if (html.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState))
                {
                    if (modelState.Errors.Count > 0)
                    {
                        this.controlHtmlAttributes.AddClass("input-validation-error");
                    }

                    if (modelState.Value != null && ((string[])modelState.Value.RawValue).Contains(this.value.ToString()))
                    {
                        this.isChecked = true;
                    }
                }

                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.Attributes.Add("type", "checkbox");
                tagBuilder.Attributes.Add("name", fullHtmlFieldName);
                tagBuilder.Attributes.Add("id", this.id);
                tagBuilder.Attributes.Add("value", this.@value.ToString());

                if (this.isChecked)
                {
                    tagBuilder.Attributes.Add("checked", "checked");
                }

                if (this.isDisabled)
                {
                    tagBuilder.Attributes.Add("disabled", "disabled");
                }

                tagBuilder.MergeHtmlAttributes(this.controlHtmlAttributes.FormatHtmlAttributes());

                return tagBuilder.ToString(TagRenderMode.SelfClosing);
            }
        }

        protected override string RenderLabeledControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            if (this.controlHtmlAttributes.Keys.Contains("id"))
            {
                labelTagBuilder.Attributes["for"] = this.controlHtmlAttributes["id"].ToString();
            }

            this.displayValidationMessage = false;

            string htmlString = MvcHtmlString.Create(this.RenderControl()).ToHtmlString();

            SetLabelText();
            if (this.labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = htmlString;
            }
            else
            {
                labelTagBuilder.InnerHtml = htmlString + this.labelText + GetRequiredStarTagBuilder().ToString();
            }

            return MvcHtmlString.Create("<div class=\"checkbox\">{0}</div>".FormatWith(labelTagBuilder.ToString(TagRenderMode.Normal))).ToHtmlString();
        }

        protected override string RenderFormGroupControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            this.validationMessage = RenderValidationMessage();

            bool isValid = this.html.ViewData.ModelState.IsValidField(this.htmlFieldName);

            return RenderFormGroupControl(string.Empty, RenderLabeledControl(), validationMessage, true);
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