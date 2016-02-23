using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;
using HyperSlackers.Bootstrap.BootstrapMethods;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for lists of controls.
    /// </summary>
    /// <typeparam name="TControlList">The type of the control list.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ControlListBase<TControlList, TModel> : FormGroupControlBase<TControlList, TModel> where TControlList : ControlListBase<TControlList, TModel>
    {
        internal int? numberOfColumns;
        internal bool displayInColumnsCondition = true;
        internal int columnPixelWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlListBase{TControlList, TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        internal ControlListBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        }

        /// <summary>
        /// Renders a list item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="controlValue">The control value.</param>
        /// <param name="controlText">The control text.</param>
        /// <param name="controlHtmlAttributes">The control HTML attributes.</param>
        /// <param name="labelHtmlAttributes">The label HTML attributes.</param>
        /// <param name="inputIsChecked">if set to <c>true</c> [input is checked].</param>
        /// <param name="inputIsDisabled">if set to <c>true</c> [input is disabled].</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual string RenderControlListItem(int index, string controlValue, string controlText, IDictionary<string, object> controlHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the control list container.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <returns></returns>
        protected virtual string RenderControlListContainer(List<string> inputs)
        {
            Contract.Requires<ArgumentNullException>(inputs != null, "inputs");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{1}{0}" : "{0}{1}";

            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("input-list-container");

            if (numberOfColumns.HasValue && displayInColumnsCondition)
            {
                int? maxWidth;
                if (numberOfColumns.HasValue)
                {
                    maxWidth = new int?(columnPixelWidth * numberOfColumns.GetValueOrDefault());
                }
                else
                {
                    maxWidth = null;
                }

                if (maxWidth.HasValue && maxWidth.Value > 0)
                {
                    tagBuilder.AddCssStyle("max-width", string.Concat(maxWidth.ToString(), "px"));
                }

                List<string> strs = new List<string>();

                TagBuilder inputTagBuilder = new TagBuilder("div");

                inputTagBuilder.AddCssClass("input-list-column");
                inputTagBuilder.AddCssStyle("width", string.Concat(columnPixelWidth.ToString(), "px"));
                inputTagBuilder.AddCssStyle("display", "inline-block");

                foreach (string input in inputs)
                {
                    inputTagBuilder.InnerHtml = input;
                    strs.Add(inputTagBuilder.ToString());
                }

                inputs = strs;
            }

            string validationHtml;
            StringBuilder controlsHtml = new StringBuilder();
            foreach (var item in inputs)
            {
                controlsHtml.Append(item);
            }

            tagBuilder.InnerHtml = controlsHtml.ToString();

            validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = RenderValidationMessage();
            }

            return string.Format(formatString, tagBuilder.ToString(0), validationHtml);
        }
    }
}
