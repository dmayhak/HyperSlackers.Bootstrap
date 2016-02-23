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
    public class DropDownListControl<TModel> : InputControlBase<DropDownListControl<TModel>, TModel>
	{
        internal readonly IEnumerable<SelectListItem> selectList;
        internal string optionLabel;
        internal readonly List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        internal readonly List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
        internal InputSize size = InputSize.Default;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(prependHtml != null);
            Contract.Invariant(appendHtml != null);
        }

		public DropDownListControl(HtmlHelper<TModel> html, string htmlFieldName, IEnumerable<SelectListItem> selectList, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.selectList = selectList;
            selectedValue = metadata.Model;
		}

		public DropDownListControl(HtmlHelper<TModel> html, string htmlFieldName, string optionLabel, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!optionLabel.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

            this.optionLabel = optionLabel;
            selectedValue = metadata.Model;
		}

        public DropDownListControl<TModel> Append(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> AppendIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> AppendIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> AppendIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> AppendIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> OptionLabel(string optionLabel)
        {
            Contract.Requires<ArgumentException>(!optionLabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            this.optionLabel = optionLabel;

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> Prepend(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));
            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> PrependIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> PrependIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> PrependIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> PrependIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> SelectedValue(object value)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            selectedValue = value;

            return (DropDownListControl<TModel>)this;
        }

        public DropDownListControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public DropDownListControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public DropDownListControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public DropDownListControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

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

            controlHtmlAttributes.AddIfNotExistsCssClass((string)Helpers.GetCssClass(html, size));

            string controlHtml = string.Empty;
            if (selectList != null)
            {
                controlHtml = html.DropDownList(htmlFieldName, selectList, optionLabel, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();
            }
            else
            {
                controlHtml = html.DropDownList(htmlFieldName, optionLabel).ToHtmlString();
            }

            formatString = AddPrependAppend(formatString, prependHtml, appendHtml);

            string helpHtml = (helpText != null ? helpText.ToHtmlString() : GetHelpTextText());
            string validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = RenderValidationMessage();
            }

            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, helpHtml, validationHtml)).ToString();
        }
	}
}