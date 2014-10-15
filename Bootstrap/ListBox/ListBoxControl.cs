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
        internal object selectedValue;
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

            this.helpText = new HelpTextControl<TModel>(this.html, GetHelpTextText());
            
            return this;
        }

        public ListBoxControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, text);
            
            return this;
        }

        public ListBoxControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());
            
            return this;
        }

        public ListBoxControl<TModel> SelectedValue(object value)
        {
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            this.selectedValue = value;

            return this;
        }

        public ListBoxControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            this.size = inputSize;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            if (this.selectedValue != null)
            {
                foreach (SelectListItem selectListItem in this.selectList)
                {
                    if (selectListItem.Value == this.selectedValue.ToString())
                    {
                        selectListItem.Selected = true;
                        break;
                    }
                }
            }

            this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

            SetDefaultTooltip();
            if (this.tooltip != null)
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            if (!this.id.IsNullOrWhiteSpace())
            {
                this.controlHtmlAttributes.AddOrReplace("id", this.id);
            }

            this.controlHtmlAttributes.AddClass("form-control");

            this.controlHtmlAttributes.AddClass(Helpers.GetCssClass(html, this.size));

            string controlHtml = html.ListBox(this.htmlFieldName, this.selectList, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            formatString = AddPrependAppend(formatString, this.prependHtml, this.appendHtml);

            string helpHtml = (this.helpText != null ? this.helpText.ToHtmlString() : string.Empty);
            string validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = this.RenderValidationMessage();
            }

            return MvcHtmlString.Create(string.Format(formatString, controlHtml, helpHtml, validationHtml)).ToString();
        }
	}
}