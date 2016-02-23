using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// Displays a summary of all validation errors on a page.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ValidationSummaryControl<TModel> : ControlBase<ValidationSummaryControl<TModel>, TModel>
	{
        internal bool closeable = true;
        internal bool excludePropertyErrors;
        internal string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationSummaryControl{TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
		public ValidationSummaryControl(HtmlHelper<TModel> html)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
		}

        /// <summary>
        /// Makes the <see cref="ValidationSummaryControl{TModel}"/> closable.
        /// </summary>
        /// <param name="closable">if set to <c>true</c> [closable].</param>
        /// <returns></returns>
        public ValidationSummaryControl<TModel> Closeable(bool closable = true)
		{
            Contract.Ensures(Contract.Result<ValidationSummaryControl<TModel>>() != null);

            closeable = closable;
			
            return this;
		}

        /// <summary>
        /// Excludes property errors from the <see cref="ValidationSummaryControl{TModel}"/>.
        /// </summary>
        /// <param name="exclude">if set to <c>true</c> [exclude].</param>
        /// <returns></returns>
        public ValidationSummaryControl<TModel> ExcludePropertyErrors(bool exclude = true)
		{
            Contract.Ensures(Contract.Result<ValidationSummaryControl<TModel>>() != null);

			excludePropertyErrors = exclude;
			
            return this;
		}

        /// <summary>
        /// Sets the message for the <see cref="ValidationSummaryControl{TModel}"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ValidationSummaryControl<TModel> Message(string message)
		{
            Contract.Requires<ArgumentException>(!message.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ValidationSummaryControl<TModel>>() != null);

			this.message = message;
			
            return this;
		}

        /// <summary>
        /// Renders this instance.
        /// </summary>
        /// <returns></returns>
		protected override string Render()
		{
            Contract.Ensures(Contract.Result<string>() != null);

            ModelState modelState = null;
            IEnumerable<string> errorMessages = new List<string>();
            if (!excludePropertyErrors)
            {
                errorMessages = html.ViewContext.ViewData.ModelState.SelectMany<KeyValuePair<string, ModelState>, string>((KeyValuePair<string, ModelState> state) =>
                    from error in state.Value.Errors
                    select error.ErrorMessage);
            }
            else
            {
                html.ViewData.ModelState.TryGetValue(html.ViewData.TemplateInfo.HtmlFieldPrefix, out modelState);
                if (modelState != null)
                {
                    errorMessages =
                        from error in modelState.Errors
                        select error.ErrorMessage;
                }
            }

            IList<string> errorMessageList = errorMessages as IList<string>;
            if (errorMessageList == null)
            {
                errorMessageList = errorMessages.ToList<string>();
            }

            int messageCount = errorMessageList.Count();

            TagBuilder tagBuilder = new TagBuilder("div");

            if (messageCount > 0)
            {
                tagBuilder.AddCssClass("alert alert-danger");
            }

            if (closeable)
            {
                TagBuilder closeTagBuilder = new TagBuilder("button");
                closeTagBuilder.AddCssClass("close");
                closeTagBuilder.MergeAttribute("type", "button");
                closeTagBuilder.MergeAttribute("data-dismiss", "alert");
                if (messageCount == 0)
                {
                    closeTagBuilder.MergeAttribute("style", "display: none;");
                }
                closeTagBuilder.InnerHtml = "&times;";

                tagBuilder.InnerHtml += closeTagBuilder.ToString();
            }

            tagBuilder.InnerHtml += html.ValidationSummary(excludePropertyErrors, message, controlHtmlAttributes);

            return new MvcHtmlString(tagBuilder.ToString()).ToHtmlString();
		}
	}
}