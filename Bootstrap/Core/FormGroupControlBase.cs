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

            this.labelWidthLg = formGroup.labelWidthLg;
            this.labelWidthMd = formGroup.labelWidthMd;
            this.labelWidthSm = formGroup.labelWidthSm;
            this.labelWidthXs = formGroup.labelWidthXs;
            this.controlWidthLg = formGroup.controlWidthLg;
            this.controlWidthMd = formGroup.controlWidthMd;
            this.controlWidthSm = formGroup.controlWidthSm;
            this.controlWidthXs = formGroup.controlWidthXs;

            this.LabelHtmlAttributes(formGroup.labelHtmlAttributes);
            this.ControlHtmlAttributes(formGroup.controlHtmlAttributes);

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
                this.controlHtmlAttributes.AddOrReplace("autofocus", null);
            }
            else
            {
                this.controlHtmlAttributes.Remove("autofocus");
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
                this.controlHtmlAttributes.AddOrReplace("disabled", "disabled");
            }
            else
            {
                this.controlHtmlAttributes.Remove("disabled");
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

            this.isReadOnly = isReadonly;

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
            if (!this.isReadOnly.HasValue)
            {
                if (this.metadata != null)
                {
                    this.isReadOnly = this.metadata.IsReadOnly;
                }
                else
                {
                    this.isReadOnly = false;
                }
            }

            if (this.isReadOnly.Value)
            {
                this.controlHtmlAttributes.AddOrReplace("readonly", "readonly");
            }
            else
            {
                this.controlHtmlAttributes.Remove("readonly");
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

            if (this.formGroup == null)
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

            bool isValid = this.htmlFieldName.IsNullOrWhiteSpace() ? true : html.ViewData.ModelState.IsValidField(this.htmlFieldName);

            return RenderFormGroupControl(controlHtml, labelHtml, validationHtml, isValid);
        }

        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <returns></returns>
        protected override string RenderLabel()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (this.formGroup != null)
            {
                string cssClass = "control-label";

                if (!this.labelWidthXs.HasValue && !this.labelWidthSm.HasValue && !this.labelWidthMd.HasValue && !this.labelWidthLg.HasValue)
                {
                    this.labelWidthLg = 2;
                }

                if (this.formGroup.formType == FormType.Horizontal)
                {
                    cssClass = cssClass.AddClass(Helpers.CssColClassWidth(this.labelWidthXs, this.labelWidthSm, this.labelWidthMd, this.labelWidthLg));
                }

                this.LabelClass(cssClass);
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
                horizontalFormControlTagBuilder.SetInnerText(formatString);
                formatString = horizontalFormControlTagBuilder.ToString();
            }

            if (!this.html.BootstrapDefaults().DefaultShowValidationMessageInline.HasValue || this.html.BootstrapDefaults().DefaultShowValidationMessageInline.Value == false) 
            {
                this.validationMessage = string.Empty;
            }

            if (!this.validationMessage.IsNullOrWhiteSpace())
            {
                TagBuilder validationTagBuilder = new TagBuilder("span");
                validationTagBuilder.AddCssClass("help-block");
                validationTagBuilder.AddCssClass(ValidationMessageInline(this.formGroup.formType, this.labelWidthXs, this.labelWidthSm, this.labelWidthMd, this.labelWidthLg, this.controlWidthXs, this.controlWidthSm, this.controlWidthMd, this.controlWidthLg));
                validationTagBuilder.InnerHtml = this.validationMessage;
                this.validationMessage = validationTagBuilder.ToString();
            }

            controlTagBuilder.InnerHtml = string.Concat(labelHtml, string.Format(formatString, controlHtml), this.validationMessage);

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

            if (!this.htmlFieldName.IsNullOrWhiteSpace())
            {
                if (displayValidationMessage && html.ValidationMessage(this.htmlFieldName) != null)
                {
                    validationHtml = html.ValidationMessage(this.htmlFieldName).ToHtmlString();
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

            if (this.formGroup != null && this.formGroup.formType == FormType.Horizontal)
            {
                if (!this.labelWidthXs.HasValue && !this.labelWidthSm.HasValue && !this.labelWidthMd.HasValue && !this.labelWidthLg.HasValue)
                {
                    this.labelWidthLg = new int?(2);
                }

                if (this.controlWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", this.controlWidthXs.Value));
                }
                else if (this.labelWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", 12 - this.labelWidthXs.Value));
                }

                if (this.controlWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", this.controlWidthSm.Value));
                }
                else if (this.labelWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", 12 - this.labelWidthSm.Value));
                }

                if (this.controlWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", this.controlWidthMd.Value));
                }
                else if (this.labelWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", 12 - this.labelWidthMd.Value));
                }

                if (this.controlWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", this.controlWidthLg.Value));
                }
                else if (this.labelWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", 12 - this.labelWidthLg.Value));
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

            if (this.formGroup.formType == FormType.Inline)
            {
                if (this.controlWidthXs.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-xs-", this.controlWidthXs.Value));
                }

                if (this.controlWidthSm.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-sm-", this.controlWidthSm.Value));
                }

                if (this.controlWidthMd.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-md-", this.controlWidthMd.Value));
                }

                if (this.controlWidthLg.HasValue)
                {
                    cssClass = cssClass.AddClass(string.Concat("col-lg-", this.controlWidthLg.Value));
                }
            }

            return cssClass;
        }
    }
}
