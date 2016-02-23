using HyperSlackers.Bootstrap.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for all labeled controls.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class LabeledControlBase<TControl, TModel> : ControlBase<TControl, TModel> where TControl : LabeledControlBase<TControl, TModel>
    {
        internal bool isLabeled = false;
        internal string htmlFieldName;
        internal ModelMetadata metadata;
        internal IDictionary<string, object> labelHtmlAttributes = new Dictionary<string, object>();
        internal string validationMessage;
        internal string labelText;
        internal bool? showRequiredStar;
        internal int? labelWidthXs;
        internal int? labelWidthSm;
        internal int? labelWidthMd;
        internal int? labelWidthLg;
        internal int? controlWidthXs;
        internal int? controlWidthSm;
        internal int? controlWidthMd;
        internal int? controlWidthLg;
        internal Tooltip tooltip; // not used by all derived types
        internal HelpTextControl<TModel> helpText; // not used by all derived types

        /// <summary>
        /// Initializes a new instance of the <see cref="LabeledControlBase{TControl, TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        internal LabeledControlBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            //x Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.htmlFieldName = htmlFieldName;
            this.metadata = metadata;
        }

        /// <summary>
        /// Indicates that the control should display a label from metadata.
        /// </summary>
        /// <returns></returns>
        public TControl Label()
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            isLabeled = true;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label to display for this control.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public TControl Label(params IHtmlString[] label)
        {
            Contract.Requires<ArgumentNullException>(label != null, "label");
            Contract.Ensures(Contract.Result<TControl>() != null);

            isLabeled = true;

            foreach (var item in label)
            {
                labelText += item.ToHtmlString();
            }

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label to display for this control.
        /// </summary>
        /// <param name="labelText">The label text.</param>
        /// <returns></returns>
        public TControl Label(string labelText)
        {
            Contract.Requires<ArgumentException>(!labelText.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            isLabeled = true;
            this.labelText = labelText;

            return (TControl)this;
        }

        /// <summary>
        /// Indicates if a required indicator should be shown or not.
        /// </summary>
        /// <param name="showRequiredStar">if set to <c>true</c> [show required star].</param>
        /// <returns></returns>
        public TControl LabelShowRequiredStar(bool showRequiredStar)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.showRequiredStar = new bool?(showRequiredStar);

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label width on large displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl LabelWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelWidthLg = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label width on medium displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl LabelWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelWidthMd = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label width on small displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl LabelWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelWidthSm = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the label width on extra-small displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl LabelWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelWidthXs = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the control width on large displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl ControlWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            controlWidthLg = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the control width on medium displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl ControlWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            controlWidthMd = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the control width on small displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl ControlWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            controlWidthSm = width;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the control width on extra-small displays.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public TControl ControlWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            controlWidthXs = width;

            return (TControl)this;
        }

        /// <summary>
        /// Adds a CSS class to the label.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public TControl LabelClass(string cssClass)
        {
            //x Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelHtmlAttributes.AddIfNotExistsCssClass(cssClass);

            return (TControl)this;
        }

        /// <summary>
        /// Adds an HTML attribute to the label.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public virtual TControl LabelHtmlAttribute(string key, object value)
        {
            Contract.Requires<ArgumentException>(!key.IsNullOrWhiteSpace());
            //x Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttribute(key, value);

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML attributes to the label.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public TControl LabelHtmlAttributes(object htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToDictionary());

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML attributes to the label.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public TControl LabelHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes);

            return (TControl)this;
        }

        /// <summary>
        /// Adds HTML data- attributes to the label.
        /// </summary>
        /// <param name="dataAttributes">The data attributes.</param>
        /// <returns></returns>
        public TControl LabelHtmlDataAttributes(object dataAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(dataAttributes != null, "dataAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttributes(dataAttributes.ToHtmlDataAttributes());

            return (TControl)this;
        }

        /// <summary>
        /// Indicates if a required star is shown or not.
        /// </summary>
        /// <param name="showRequiredStar">if set to <c>true</c> [show required star].</param>
        /// <returns></returns>
        public TControl ShowRequiredStar(bool showRequiredStar = true)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.showRequiredStar = showRequiredStar;

            return (TControl)this;
        }

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (!isLabeled)
            {
                return base.Render();
            }

            return RenderLabeledControl();
        }

        /// <summary>
        /// Renders the labeled control.
        /// </summary>
        /// <returns></returns>
        protected virtual string RenderLabeledControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return RenderLabel() + RenderControl();
        }

        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <returns></returns>
        protected virtual string RenderLabel()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            // TODO: manage validation message show hide more explicitly?
            SetLabelText();

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            if (labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = labelText + " " + validationMessage;
            }
            else
            {
                labelTagBuilder.InnerHtml = labelText + GetRequiredStarTagBuilder().ToString() + " " + validationMessage;
            }

            return MvcHtmlString.Create(labelTagBuilder.ToString(TagRenderMode.Normal)).ToHtmlString();
        }

        /// <summary>
        /// Gets the full name of the HTML field.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFullHtmlFieldName()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (htmlFieldName.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
        }

        /// <summary>
        /// Sets the label text.
        /// </summary>
        protected virtual void SetLabelText()
        {
            if (!labelText.IsNullOrWhiteSpace())
            {
                return;
            }

            string displayName = null;

            if (metadata != null)
            {
                displayName = metadata.DisplayName;

                if (displayName == null)
                {
                    if (metadata.PropertyName != null)
                    {
                        displayName = metadata.PropertyName.SpaceOnUpperCase();
                    }
                    else
                    {
                        displayName = null;
                    }
                }
            }

            if (displayName == null)
            {
                displayName = GetFullHtmlFieldName().Split('.').Last().SpaceOnUpperCase();
            }

            labelText = displayName;
        }

        /// <summary>
        /// Gets the label tag builder.
        /// </summary>
        /// <returns></returns>
        protected virtual TagBuilder GetLabelTagBuilder()
        {
            Contract.Ensures(Contract.Result<TagBuilder>() != null);

            TagBuilder labelTagBuilder = new TagBuilder("label");

            labelTagBuilder.Attributes.Add("for", string.Concat(GetFullHtmlFieldName().FormatForMvcInputId(), (index.HasValue ? string.Concat("_", index.Value) : string.Empty)));
            labelTagBuilder.MergeHtmlAttributes(labelHtmlAttributes.FormatHtmlAttributes());

            return labelTagBuilder;
        }

        /// <summary>
        /// Gets the required star tag builder.
        /// </summary>
        /// <returns></returns>
        protected virtual TagBuilder GetRequiredStarTagBuilder()
        {
            Contract.Ensures(Contract.Result<TagBuilder>() != null);

            TagBuilder requiredStarTagBuilder = new TagBuilder("span");

            requiredStarTagBuilder.AddCssClass("required");
            requiredStarTagBuilder.SetInnerText("*");

            bool showRequiredStar;
            if (this.showRequiredStar.HasValue)
            {
                showRequiredStar = this.showRequiredStar.GetValueOrDefault();
            }
            else if (html.BootstrapDefaults().DefaultShowRequiredStar.HasValue)
            {
                showRequiredStar = (labelText.IsNullOrWhiteSpace() ? false : html.BootstrapDefaults().DefaultShowRequiredStar.Value);
            }
            else
            {
                showRequiredStar = (labelText.IsNullOrWhiteSpace() || metadata == null ? false : metadata.IsRequired);
            }

            if (!showRequiredStar)
            {
                requiredStarTagBuilder.AddCssStyle("visibility", "hidden");
            }

            return requiredStarTagBuilder;
        }

        /// <summary>
        /// Gets the tooltip text.
        /// </summary>
        /// <returns></returns>
        protected string GetTooltipText()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (metadata == null)
            {
                return string.Empty;
            }

            if (metadata.Description.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return metadata.Description;
        }

        /// <summary>
        /// Gets the placeholder text.
        /// </summary>
        /// <returns></returns>
        protected string GetPlaceholderText()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (metadata == null)
            {
                return string.Empty;
            }

            if (!metadata.Watermark.IsNullOrWhiteSpace())
            {
                return metadata.Watermark;
            }

            if (!metadata.DisplayName.IsNullOrWhiteSpace())
            {
                return metadata.DisplayName;
            }

            if (!metadata.PropertyName.IsNullOrWhiteSpace())
            {
                return metadata.PropertyName.SpaceOnUpperCase();
            }

            return htmlFieldName.SpaceOnUpperCase();
        }

        /// <summary>
        /// Gets the help text.
        /// </summary>
        /// <returns></returns>
        protected string GetHelpTextText()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (metadata == null)
            {
                return string.Empty;
            }

            if (!metadata.AdditionalValues.ContainsKey("HelpText"))
            {
                return string.Empty;
            }

            if (metadata.AdditionalValues["HelpText"].ToString().IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return metadata.AdditionalValues["HelpText"].ToString();
        }

        /// <summary>
        /// Sets the default tooltip.
        /// </summary>
        protected void SetDefaultTooltip()
        {
            if (tooltip == null && html.BootstrapDefaults().DefaultShowTooltip)
            {
                string tooltipText = GetTooltipText();

                if (!tooltipText.IsNullOrWhiteSpace())
                {
                    tooltip = new Tooltip(tooltipText);
                }
            }
        }

        /// <summary>
        /// Sets the default help text.
        /// </summary>
        protected void SetDefaultHelpText()
        {
            if (helpText == null && html.BootstrapDefaults().DefaultShowHelpText)
            {
                string helpTextText = GetHelpTextText();

                if (!helpTextText.IsNullOrWhiteSpace())
                {
                    helpText = new HelpTextControl<TModel>(html, helpTextText);
                }
            }
        }
    }
}
