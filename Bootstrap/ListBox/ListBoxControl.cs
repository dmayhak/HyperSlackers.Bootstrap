using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Core;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class ListBoxControl<TModel> : InputControlBase<ListBoxControl<TModel>, TModel>
	{
        internal IEnumerable<SelectListItem> selectList;
        internal List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        internal List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
        internal InputSize size = InputSize.Default;

		internal ListBoxControl(HtmlHelper<TModel> html, string htmlFieldName, IEnumerable<SelectListItem> selectList, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.selectList = selectList;
		}

        public ListBoxControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public ListBoxControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public ListBoxControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public ListBoxControl<TModel> SelectedValue(object value)
        {
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            selectedValue = value;

            return this;
        }

        public ListBoxControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            size = inputSize;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            if (selectedValue != null)
            {
                foreach (SelectListItem selectListItem in selectList)
                {
                    if (selectListItem.Value == selectedValue.ToString())
                    {
                        selectListItem.Selected = true;
                        break;
                    }
                }
            }

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

            controlHtmlAttributes.AddIfNotExistsCssClass("form-control");

            controlHtmlAttributes.AddIfNotExistsCssClass(Helpers.GetCssClass(html, size));

            string controlHtml = html.ListBox(htmlFieldName, selectList, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            formatString = AddPrependAppend(formatString, prependHtml, appendHtml);

            string helpHtml = (helpText != null ? helpText.ToHtmlString() : string.Empty);
            string validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = RenderValidationMessage();
            }

            return MvcHtmlString.Create(string.Format(formatString, controlHtml, helpHtml, validationHtml)).ToString();
        }
	}
}