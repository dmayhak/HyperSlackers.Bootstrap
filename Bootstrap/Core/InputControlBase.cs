using HyperSlackers.Bootstrap.BootstrapMethods;
using HyperSlackers.Bootstrap.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for input-type controls.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class InputControlBase<TControl, TModel> : FormGroupControlBase<TControl, TModel> where TControl : InputControlBase<TControl, TModel>
    {
        internal string format;
        internal object value;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputControlBase{TControl, TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        internal InputControlBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            //x Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        }

        /// <summary>
        /// Sets the control's value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public TControl Value(object value)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.value = value;

            return (TControl)this;
        }

        /// <summary>
        /// Displays a tooltip if one is specified in metadata.
        /// </summary>
        /// <returns></returns>
        public TControl Tooltip()
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            SetDefaultTooltip();

            return (TControl)this;
        }

        /// <summary>
        /// Adds the specified tooltip to the control.
        /// </summary>
        /// <param name="tooltip">The tooltip.</param>
        /// <returns></returns>
        public TControl Tooltip(Tooltip tooltip)
        {
            Contract.Requires<ArgumentNullException>(tooltip != null, "tooltip");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.tooltip = tooltip;

            return (TControl)this;
        }

        /// <summary>
        /// Adds a tooltip with the specified test to the control.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public TControl Tooltip(string text)
        {
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.tooltip = new Tooltip(text);

            return (TControl)this;
        }

        /// <summary>
        /// Adds a tooltip with the specified test to the control.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public TControl Tooltip(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.tooltip = new Tooltip(html);

            return (TControl)this;
        }

        /// <summary>
        /// Sets the display format text.
        /// </summary>
        protected virtual void SetFormatText()
        {
            if (!this.format.IsNullOrWhiteSpace())
            {
                return;
            }

            string format = null;

            if (this.metadata != null)
            {
                format = this.metadata.DisplayFormatString;   //there is one for Edit too!!!!!
            }

            if (!format.IsNullOrWhiteSpace())
            {
                this.format = format;
            }
        }

        /// <summary>
        /// Adds any specified prepend/append items to the control.
        /// </summary>
        /// <param name="combinedHtml">The combined HTML.</param>
        /// <param name="prependHtml">The prepend HTML.</param>
        /// <param name="appendHtml">The append HTML.</param>
        /// <returns></returns>
        protected string AddPrependAppend(string combinedHtml, List<Tuple<IHtmlString, object>> prependHtml, List<Tuple<IHtmlString, object>> appendHtml)
        {
            Contract.Requires<ArgumentNullException>(prependHtml != null, "prependHtml");
            Contract.Requires<ArgumentNullException>(appendHtml != null, "appendHtml");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            if (prependHtml.Count == 0 && appendHtml.Count == 0)
            {
                return combinedHtml; // TODO: is this always "{0}"?
            }

            TagBuilder divTagBuilder = new TagBuilder("div");
            string prepend = "";
            string append = "";

            if (prependHtml.Count > 0)
            {
                divTagBuilder.AddCssClass("input-group");

                foreach (var item in prependHtml)
                {
                    string htmlString = item.Item1.ToHtmlString();
                    bool isButton = htmlString.Contains("btn");
                    TagBuilder tagBuilder = new TagBuilder("span");

                    if (item.Item2 != null)
                    {
                        tagBuilder.MergeHtmlAttributes(item.Item2.ToDictionary().FormatHtmlAttributes());
                    }

                    if (isButton)
                    {
                        tagBuilder.AddOrMergeCssClass("input-group-btn");
                    }
                    else
                    {
                        tagBuilder.AddOrMergeCssClass("input-group-addon");
                    }

                    tagBuilder.InnerHtml = htmlString;

                    prepend = tagBuilder.ToString();
                }
            }

            if (appendHtml.Count > 0)
            {
                divTagBuilder.AddCssClass("input-group");

                foreach (var item in appendHtml)
                {
                    string htmlString = item.Item1.ToHtmlString();
                    bool isButton = htmlString.Contains("btn");
                    TagBuilder tagBuilder = new TagBuilder("span");

                    if (item.Item2 != null)
                    {
                        tagBuilder.MergeHtmlAttributes(item.Item2.ToDictionary().FormatHtmlAttributes());
                    }

                    if (isButton)
                    {
                        tagBuilder.AddCssClass("input-group-btn");
                    }
                    else
                    {
                        tagBuilder.AddCssClass("input-group-addon");
                    }

                    tagBuilder.InnerHtml = htmlString;

                    append = tagBuilder.ToString();
                }
            }

            divTagBuilder.InnerHtml = prepend + "{0}" + append;

            bool showValidationMessageBeforeInput = this.html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;

            if (showValidationMessageBeforeInput)
            {
                return "{2}" + divTagBuilder.ToString(TagRenderMode.Normal) + "{1}";
            }
            else
            {
                return divTagBuilder.ToString(TagRenderMode.Normal) + "{1}{2}";
            }
        }
    }
}
