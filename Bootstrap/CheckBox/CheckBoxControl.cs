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

            isChecked = (metadata.Model == null ? false : (metadata.Model.GetType() == typeof(bool) ? (bool)metadata.Model : false));
		}

        internal CheckBoxControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, object value, bool isSingleInput)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            //x Contract.Requires<ArgumentNullException>(value != null, "value");

            isChecked = (metadata.Model == null ? false : (metadata.Model.GetType() == typeof(bool) ? (bool)metadata.Model : false));
            selectedValue = value;
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

            if (!isSingleInput) // TODO: what does this flag really mean?
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

                SetDefaultTooltip();
                if (tooltip != null)
                {
                    controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
                }

                if (!id.IsNullOrWhiteSpace())
                {
                    controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", id);
                }

                string validationHtml = RenderValidationMessage();

                return string.Concat(html.CheckBox(htmlFieldName, isChecked, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString(), validationHtml);
            }
            else
            {
                ModelState modelState = null;
                string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

                controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

                SetDefaultTooltip();
                if (tooltip != null)
                {
                    controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
                }

                if (html.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState))
                {
                    if (modelState.Errors.Count > 0)
                    {
                        controlHtmlAttributes.AddIfNotExistsCssClass("input-validation-error");
                    }

                    if (modelState.Value != null && ((string[])modelState.Value.RawValue).Contains(selectedValue.ToString()))
                    {
                        isChecked = true;
                    }
                }

                TagBuilder tagBuilder = new TagBuilder("input");
                tagBuilder.Attributes.Add("type", "checkbox");
                tagBuilder.Attributes.Add("name", fullHtmlFieldName);
                tagBuilder.Attributes.Add("id", id);
                tagBuilder.Attributes.Add("value", selectedValue.ToString());

                if (isChecked)
                {
                    tagBuilder.Attributes.Add("checked", "checked");
                }

                if (isDisabled)
                {
                    tagBuilder.Attributes.Add("disabled", "disabled");
                }

                tagBuilder.MergeHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());

                return tagBuilder.ToString(TagRenderMode.SelfClosing);
            }
        }

        protected override string RenderLabeledControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            if (controlHtmlAttributes.Keys.Contains("id"))
            {
                labelTagBuilder.Attributes["for"] = controlHtmlAttributes["id"].ToString();
            }

            displayValidationMessage = false;

            string htmlString = MvcHtmlString.Create(RenderControl()).ToHtmlString();

            SetLabelText();
            if (labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = htmlString;
            }
            else
            {
                labelTagBuilder.InnerHtml = htmlString + labelText + GetRequiredStarTagBuilder().ToString();
            }

            return MvcHtmlString.Create("<div class=\"checkbox\">{0}</div>".FormatWith(labelTagBuilder.ToString(TagRenderMode.Normal))).ToHtmlString();
        }

        protected override string RenderFormGroupControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            validationMessage = RenderValidationMessage();

            bool isValid = html.ViewData.ModelState.IsValidField(htmlFieldName);

            return RenderFormGroupControl(string.Empty, RenderLabeledControl(), validationMessage, true);
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