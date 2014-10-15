using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DropDownListFromEnumControl<TModel> : InputControlBase<DropDownListFromEnumControl<TModel>, TModel>
	{
        internal readonly IEnumerable<SelectListItem> selectList;
        internal string optionLabel;
        internal readonly List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        internal readonly List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();

		internal DropDownListFromEnumControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata) 
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.selectList = metadata.SelectListItemsFromEnumMetadata();
            this.value = metadata.Model;
		}

		public DropDownListFromEnumControl<TModel> Append(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> AppendIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> AppendIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> AppendIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> AppendIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> OptionLabel(string optionLabel)
        {
            Contract.Requires<ArgumentException>(!optionLabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.optionLabel = optionLabel;

            return this;
        }

        public DropDownListFromEnumControl<TModel> Prepend(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));
            return this;
        }

        public DropDownListFromEnumControl<TModel> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> PrependIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> PrependIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> PrependIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> PrependIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel> SelectedValue(object value)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            this.value = value;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{1}{0}" : "{0}{1}";

            if (this.value != null)
            {
                foreach (SelectListItem selectListItem in this.selectList)
                {
                    if (selectListItem.Value == this.value.ToString())
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

            string controlHtml = string.Empty;
            if (this.selectList != null)
            {
                controlHtml = html.DropDownList(this.htmlFieldName, this.selectList, this.optionLabel, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();
            }
            else
            {
                controlHtml = html.DropDownList(this.htmlFieldName, this.optionLabel).ToHtmlString();
            }

            formatString = AddPrependAppend(formatString, this.prependHtml, this.appendHtml);

            string validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = this.RenderValidationMessage();
            }

            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, validationHtml)).ToString();
        }
    }
}