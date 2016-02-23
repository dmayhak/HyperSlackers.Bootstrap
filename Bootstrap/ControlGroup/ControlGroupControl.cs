using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class ControlGroupControl<TModel> : FormGroupControlBase<ControlGroupControl<TModel>, TModel>
    {
        internal List<IHtmlString> controls;
        internal bool addSpaces;

        internal ControlGroupControl(HtmlHelper<TModel> html, List<IHtmlString> controls)
            : base(html, string.Empty, null)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(controls != null, "controls");

            this.controls = controls;
        }

        public ControlGroupControl<TModel> SpaceControls(bool addSpace = true)
        {
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            addSpaces = addSpace;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            StringBuilder controlHtml = new StringBuilder();

            foreach (var item in controls)
            {
                if (addSpaces && controlHtml.Length > 0)
                {
                    controlHtml.Append(" ");
                }

                controlHtml.Append(item.ToHtmlString());
            }

            return MvcHtmlString.Create(controlHtml.ToString()).ToString();
        }

        protected override string RenderFormGroupControl(string controlHtml, string labelHtml, string validationMessage, bool fieldIsValid = true)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (!labelText.IsNullOrWhiteSpace())
            {
                return base.RenderFormGroupControl(controlHtml, labelHtml, validationMessage, fieldIsValid);
            }

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

            controlTagBuilder.InnerHtml = formatString.FormatWith(controlHtml);

            return controlTagBuilder.ToString();
        }
    }
}
