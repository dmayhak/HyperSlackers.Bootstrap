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

            this.isLabeled = true;

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

            this.isLabeled = true;

            foreach (var item in label)
            {
                this.labelText += item.ToHtmlString();
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

            this.isLabeled = true;
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

            this.labelWidthLg = width;

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

            this.labelWidthMd = width;

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

            this.labelWidthSm = width;

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

            this.labelWidthXs = width;

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

            this.controlWidthLg = width;

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

            this.controlWidthMd = width;

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

            this.controlWidthSm = width;

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

            this.controlWidthXs = width;

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

            this.labelHtmlAttributes.AddClass(cssClass);

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

            this.labelHtmlAttributes.MergeHtmlAttribute(key, value);

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

            this.labelHtmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

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

            this.labelHtmlAttributes.MergeHtmlAttributes(htmlAttributes);

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

            this.labelHtmlAttributes.MergeHtmlAttributes(dataAttributes.ToHtmlDataAttributes());

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

            if (!this.isLabeled)
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

            if (this.labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = this.labelText + " " + this.validationMessage;
            }
            else
            {
                labelTagBuilder.InnerHtml = this.labelText + GetRequiredStarTagBuilder().ToString() + " " + this.validationMessage;
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

            if (this.htmlFieldName.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(this.htmlFieldName);
        }

        /// <summary>
        /// Sets the label text.
        /// </summary>
        protected virtual void SetLabelText()
        {
            if (!this.labelText.IsNullOrWhiteSpace())
            {
                return;
            }

            string displayName = null;

            if (this.metadata != null)
            {
                displayName = this.metadata.DisplayName;

                if (displayName == null)
                {
                    if (this.metadata.PropertyName != null)
                    {
                        displayName = this.metadata.PropertyName.SpaceOnUpperCase();
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

            this.labelText = displayName;
        }

        /// <summary>
        /// Gets the label tag builder.
        /// </summary>
        /// <returns></returns>
        protected virtual TagBuilder GetLabelTagBuilder()
        {
            Contract.Ensures(Contract.Result<TagBuilder>() != null);

            TagBuilder labelTagBuilder = new TagBuilder("label");

            labelTagBuilder.Attributes.Add("for", string.Concat(GetFullHtmlFieldName().FormatForMvcInputId(), (this.index.HasValue ? string.Concat("_", this.index.Value) : string.Empty)));
            labelTagBuilder.MergeHtmlAttributes(this.labelHtmlAttributes.FormatHtmlAttributes());

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
                showRequiredStar = (this.labelText.IsNullOrWhiteSpace() ? false : html.BootstrapDefaults().DefaultShowRequiredStar.Value);
            }
            else
            {
                showRequiredStar = (this.labelText.IsNullOrWhiteSpace() || this.metadata == null ? false : this.metadata.IsRequired);
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

            if (this.metadata == null)
            {
                return string.Empty;
            }

            if (this.metadata.Description.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return this.metadata.Description;
        }

        /// <summary>
        /// Gets the placeholder text.
        /// </summary>
        /// <returns></returns>
        protected string GetPlaceholderText()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (this.metadata == null)
            {
                return string.Empty;
            }

            if (!this.metadata.Watermark.IsNullOrWhiteSpace())
            {
                return this.metadata.Watermark;
            }

            if (!this.metadata.DisplayName.IsNullOrWhiteSpace())
            {
                return this.metadata.DisplayName;
            }

            if (!metadata.PropertyName.IsNullOrWhiteSpace())
            {
                return this.metadata.PropertyName.SpaceOnUpperCase();
            }

            return this.htmlFieldName.SpaceOnUpperCase();
        }

        /// <summary>
        /// Gets the help text.
        /// </summary>
        /// <returns></returns>
        protected string GetHelpTextText()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (this.metadata == null)
            {
                return string.Empty;
            }

            if (!this.metadata.AdditionalValues.ContainsKey("HelpText"))
            {
                return string.Empty;
            }

            if (this.metadata.AdditionalValues["HelpText"].ToString().IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return this.metadata.AdditionalValues["HelpText"].ToString();
        }

        /// <summary>
        /// Sets the default tooltip.
        /// </summary>
        protected void SetDefaultTooltip()
        {
            if (this.tooltip == null && this.html.BootstrapDefaults().DefaultShowTooltip)
            {
                string tooltipText = GetTooltipText();

                if (!tooltipText.IsNullOrWhiteSpace())
                {
                    this.tooltip = new Tooltip(tooltipText);
                }
            }
        }

        /// <summary>
        /// Sets the default help text.
        /// </summary>
        protected void SetDefaultHelpText()
        {
            if (this.helpText == null && this.html.BootstrapDefaults().DefaultShowHelpText)
            {
                string helpTextText = GetHelpTextText();

                if (!helpTextText.IsNullOrWhiteSpace())
                {
                    this.helpText = new HelpTextControl<TModel>(this.html, helpTextText);
                }
            }
        }
    }
}
