using HyperSlackers.Bootstrap.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for form group controls.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class FormGroupControlBase<TControl, TModel> : LabeledControlBase<TControl, TModel> where TControl : FormGroupControlBase<TControl, TModel>
    {
        internal FormGroup<TModel> formGroup;
        internal bool isDisabled;
        internal bool? isReadOnly;
        internal bool displayValidationMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormGroupControlBase{TControl, TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        internal FormGroupControlBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            //x Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        }

        /// <summary>
        /// Sets the form group for this control.
        /// </summary>
        /// <param name="formGroup">The form group.</param>
        /// <returns></returns>
        internal TControl FormGroup(FormGroup<TModel> formGroup)
        {
            Contract.Requires<ArgumentNullException>(formGroup != null, "formGroup");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.formGroup = formGroup;

            labelWidthLg = formGroup.labelWidthLg;
            labelWidthMd = formGroup.labelWidthMd;
            labelWidthSm = formGroup.labelWidthSm;
            labelWidthXs = formGroup.labelWidthXs;
            controlWidthLg = formGroup.controlWidthLg;
            controlWidthMd = formGroup.controlWidthMd;
            controlWidthSm = formGroup.controlWidthSm;
            controlWidthXs = formGroup.controlWidthXs;

            LabelHtmlAttributes(formGroup.labelHtmlAttributes);
            ControlHtmlAttributes(formGroup.controlHtmlAttributes);

            return (TControl)this;
        }

        /// <summary>
        /// Indicates that this control should be auto-focused or not.
        /// </summary>
        /// <param name="isFocused">if set to <c>true</c> [is focused].</param>
        /// <returns></returns>
        public virtual TControl AutoFocus(bool isFocused = true)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            // TODO: for lists, should we only set first control to autofocus, or ignore it, or what???  or move this to input control base/
            if (isFocused)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("autofocus", null);
            }
            else
            {
                controlHtmlAttributes.Remove("autofocus");
            }

            return (TControl)this;
        }

        /// <summary>
        /// Disables this control.
        /// </summary>
        /// <param name="isDisabled">if set to <c>true</c> [is disabled].</param>
        /// <returns></returns>
        public virtual TControl Disabled(bool isDisabled = true)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.isDisabled = isDisabled;

            if (isDisabled)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("disabled", "disabled");
            }
            else
            {
                controlHtmlAttributes.Remove("disabled");
            }

            return (TControl)this;
        }

        /// <summary>
        /// Sets this control to readonly.
        /// </summary>
        /// <param name="isReadonly">if set to <c>true</c> [is readonly].</param>
        /// <returns></returns>
        public virtual TControl Readonly(bool isReadonly = true)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            isReadOnly = isReadonly;

            return (TControl)this;
        }

        /// <summary>
        /// Indicates that a validation message should be shown.
        /// </summary>
        /// <param name="displayValidationMessage">if set to <c>true</c> [display validation message].</param>
        /// <returns></returns>
        public virtual TControl ShowValidationMessage(bool displayValidationMessage)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.displayValidationMessage = displayValidationMessage;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the read only attribute.
        /// </summary>
        protected void SetReadOnlyAttribute()
        {
            if (!isReadOnly.HasValue)
            {
                if (metadata != null)
                {
                    isReadOnly = metadata.IsReadOnly;
                }
                else
                {
                    isReadOnly = false;
                }
            }

            if (isReadOnly.Value)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("readonly", "readonly");
            }
            else
            {
                controlHtmlAttributes.Remove("readonly");
            }
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            SetReadOnlyAttribute(); // TODO: is this the place for this?

            if (formGroup == null)
            {
                return base.Render();
            }

            return RenderFormGroupControl();
        }

        /// <summary>
        /// Renders the form group control.
        /// </summary>
        /// <returns></returns>
        protected virtual string RenderFormGroupControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string controlHtml = RenderControl();
            string labelHtml = RenderLabel();
            string validationHtml = RenderValidationMessage();

            bool isValid = htmlFieldName.IsNullOrWhiteSpace() ? true : html.ViewData.ModelState.IsValidField(htmlFieldName);

            return RenderFormGroupControl(controlHtml, labelHtml, validationHtml, isValid);
        }

        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <returns></returns>
        protected override string RenderLabel()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (formGroup != null)
            {
                string cssClass = "control-label";

                if (formGroup.formType == FormType.Horizontal)
                {
                    if (!labelWidthXs.HasValue && !labelWidthSm.HasValue && !labelWidthMd.HasValue && !labelWidthLg.HasValue)
                    {
                        labelWidthSm = 2;
                    }

                    cssClass = cssClass.AddClass(Helpers.CssColClassWidth(labelWidthXs, labelWidthSm, labelWidthMd, labelWidthLg));
                }

                LabelClass(cssClass);
            }

            return base.RenderLabel();
        }

        /// <summary>
        /// Renders the form group control.
        /// </summary>
        /// <param name="controlHtml">The control HTML.</param>
        /// <param name="labelHtml">The label HTML.</param>
        /// <param name="validationMessage">The validation message.</param>
        /// <param name="fieldIsValid">if set to <c>true</c> [field is valid].</param>
        /// <returns></returns>
        protected virtual string RenderFormGroupControl(string controlHtml, string labelHtml, string validationMessage, bool fieldIsValid = true)
        {
            Contract.Requires<ArgumentNullException>(controlHtml != null, "controlHtml");
            Contract.Requires<ArgumentNullException>(labelHtml != null, "labelHtml");
            Contract.Requires<ArgumentNullException>(validationMessage != null, "validationMessage");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder controlTagBuilder = new TagBuilder("div");
            controlTagBuilder.MergeHtmlAttributes(formGroup.formGroupHtmlAttributes.FormatHtmlAttributes());
            controlTagBuilder.AddOrMergeCssClass("form-group");

            controlTagBuilder.AddOrMergeCssClass((string)Helpers.GetCssClass(html, formGroup.size).Replace("input", "form-group"));

            if (!fieldIsValid)
            {
                formGroup.validationState = FormGroupValidationState.Error;
            }

            if (formGroup.validationState == FormGroupValidationState.Error)
            {
                controlTagBuilder.AddCssClass("has-error");
            }
            else if (formGroup.validationState == FormGroupValidationState.Warning)
            {
                controlTagBuilder.AddCssClass("has-warning");
            }
            else if (formGroup.validationState == FormGroupValidationState.Success)
            {
                controlTagBuilder.AddCssClass("has-success");
            }

            if (formGroup.feedbackIcon != null)
            {
                controlTagBuilder.AddCssClass("has-feedback");
            }

            controlTagBuilder.AddCssClass(GetFormGroupControlCssClass());

            string formatString = "{0}";

            if (formGroup.formType == FormType.Horizontal)
            {
                TagBuilder horizontalFormControlTagBuilder = new TagBuilder("div");
                horizontalFormControlTagBuilder.MergeAttributes<string, object>(formGroup.controlHtmlAttributes);
                horizontalFormControlTagBuilder.AddCssClass(GetHorizontalFromGroupControlCssClass());
                horizontalFormControlTagBuilder.SetInnerText(formatString);
                formatString = horizontalFormControlTagBuilder.ToString();
            }

            if (!html.BootstrapDefaults().DefaultShowValidationMessageInline.HasValue || html.BootstrapDefaults().DefaultShowValidationMessageInline.Value == false)
            {
                this.validationMessage = string.Empty;
            }

            if (!this.validationMessage.IsNullOrWhiteSpace())
            {
                TagBuilder validationTagBuilder = new TagBuilder("span");
                validationTagBuilder.AddCssClass("help-block");
                validationTagBuilder.AddCssClass(ValidationMessageInline(formGroup.formType, labelWidthXs, labelWidthSm, labelWidthMd, labelWidthLg, controlWidthXs, controlWidthSm, controlWidthMd, controlWidthLg));
                validationTagBuilder.InnerHtml = this.validationMessage;
                this.validationMessage = validationTagBuilder.ToString();
            }

            controlTagBuilder.InnerHtml = string.Concat(labelHtml, formatString.FormatWith(controlHtml), this.validationMessage);

            return controlTagBuilder.ToString();
        }

        /// <summary>
        /// Renders the validation message.
        /// </summary>
        /// <returns></returns>
        protected virtual string RenderValidationMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string validationHtml = string.Empty;

            if (!htmlFieldName.IsNullOrWhiteSpace())
            {
                if (displayValidationMessage && html.ValidationMessage(htmlFieldName) != null)
                {
                    validationHtml = html.ValidationMessage(htmlFieldName).ToHtmlString();
                }
            }

            return validationHtml;
        }

        internal static string ValidationMessageInline(FormType formType, int? labelXs, int? labelSm, int? labelMd, int? labelLg, int? inputXs, int? inputSm, int? inputMd, int? inputLg)
        {
            if (formType != FormType.Horizontal)
            {
                return string.Empty;
            }

            if (!labelXs.HasValue && !labelSm.HasValue && !labelMd.HasValue && !labelLg.HasValue)
            {
                labelLg = new int?(2);
            }

            string cssClass = string.Empty;

            if (labelXs.HasValue && inputXs.HasValue)
            {
                cssClass.AddClass("col-xs-" + (12 - labelXs.GetValueOrDefault() - inputXs.GetValueOrDefault()).ToString()); // TODO: these can return 0?????
            }

            if (labelSm.HasValue && inputSm.HasValue)
            {
                cssClass.AddClass("col-sm-" + (12 - labelSm.GetValueOrDefault() - inputSm.GetValueOrDefault()).ToString());
            }

            if (labelMd.HasValue && inputMd.HasValue)
            {
                cssClass.AddClass("col-md-" + (12 - labelMd.GetValueOrDefault() - inputMd.GetValueOrDefault()).ToString());
            }

            if (labelLg.HasValue && inputLg.HasValue)
            {
                cssClass.AddClass("col-lg-" + (12 - labelLg.GetValueOrDefault() - inputLg.GetValueOrDefault()).ToString());
            }

            return cssClass;
        }

        /// <summary>
        /// Gets the horizontal from group control CSS class.
        /// </summary>
        /// <returns></returns>
        protected string GetHorizontalFromGroupControlCssClass()
        {
            string cssClass = string.Empty;

            if (formGroup != null && formGroup.formType == FormType.Horizontal)
            {
                if (!labelWidthXs.HasValue && !labelWidthSm.HasValue && !labelWidthMd.HasValue && !labelWidthLg.HasValue)
                {
                    labelWidthLg = new int?(2);
                }

                if (controlWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", controlWidthXs.Value));
                }
                else if (labelWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", 12 - labelWidthXs.Value));
                }

                if (controlWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", controlWidthSm.Value));
                }
                else if (labelWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", 12 - labelWidthSm.Value));
                }

                if (controlWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", controlWidthMd.Value));
                }
                else if (labelWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", 12 - labelWidthMd.Value));
                }

                if (controlWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", controlWidthLg.Value));
                }
                else if (labelWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", 12 - labelWidthLg.Value));
                }
            }

            return cssClass;
        }

        /// <summary>
        /// Gets the form group control CSS class.
        /// </summary>
        /// <returns></returns>
        protected string GetFormGroupControlCssClass()
        {
            string cssClass = "";

            if (formGroup.formType == FormType.Inline)
            {
                if (controlWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", controlWidthXs.Value));
                }

                if (controlWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", controlWidthSm.Value));
                }

                if (controlWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", controlWidthMd.Value));
                }

                if (controlWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", controlWidthLg.Value));
                }
            }

            return cssClass;
        }
    }
}
