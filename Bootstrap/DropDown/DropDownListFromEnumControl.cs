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
    public class DropDownListFromEnumControl<TModel, TValue> : InputControlBase<DropDownListFromEnumControl<TModel, TValue>, TModel>
        where TValue : struct, IConvertible
    {
        internal readonly IEnumerable<SelectListItem> selectList;
        internal string optionLabel;
        internal readonly List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        internal readonly List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
        internal InputSize size = InputSize.Default;

        internal DropDownListFromEnumControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentException>(typeof(TValue).IsEnum);

            selectList = GetSelectListItemsFromEnum();
            selectedValue = metadata.Model;
		}

		public DropDownListFromEnumControl<TModel, TValue> Append(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> AppendIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> AppendIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> AppendIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> AppendIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            appendHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> OptionLabel(string optionLabel)
        {
            Contract.Requires<ArgumentException>(!optionLabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            this.optionLabel = optionLabel;

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> Prepend(string htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));
            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> PrependIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentNullException>(icon != null, "icon");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> PrependIcon(GlyphIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> PrependIcon(FontAwesomeIconType icon, object containerHtmlAttributes = null)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new FontAwesomeIcon(icon), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> PrependIcon(string cssClass, object containerHtmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            prependHtml.Add(new Tuple<IHtmlString, object>(new GlyphIcon(cssClass), containerHtmlAttributes));

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            size = inputSize;

            return this;
        }

        public DropDownListFromEnumControl<TModel, TValue> SelectedValue(object value)
        {
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            selectedValue = value;

            return this;
        }

        // TODO: remove this
        //protected IEnumerable<SelectListItem> GetSelectListItemsFromEnumMetadata(ModelMetadata metadata)
        //{
        //    Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        //    Contract.Ensures(Contract.Result<IEnumerable<SelectListItem>>() != null);

        //    Type modelType = metadata.ModelType;

        //    if (modelType.IsNullableEnum() || modelType.IsGenericEnumerable())
        //    {
        //        modelType = modelType.GetGenericArguments().First<Type>();
        //    }

        //    if (modelType.IsArray)
        //    {
        //        modelType = modelType.GetElementType();
        //    }

        //    List<SelectListItem> selectListItems = new List<SelectListItem>();

        //    foreach (Enum @enum in Enum.GetValues(modelType).OfType<Enum>())
        //    {
        //        SelectListItem selectListItem = new SelectListItem();
        //        selectListItem.Value = Enum.Parse(modelType, @enum.ToString()).ToString();
        //        selectListItem.Text = @enum.GetEnumDescription();
        //        selectListItem.Selected = @enum.Equals(metadata.Model);
        //        selectListItems.Add(selectListItem);
        //    }

        //    return selectListItems;
        //}

        protected IEnumerable<SelectListItem> GetSelectListItemsFromEnum()
        {
            Contract.Ensures(Contract.Result<IEnumerable<SelectListItem>>() != null);

            Type t = typeof(TValue);

            if (t.IsNullableEnum() || t.IsGenericEnumerable())
            {
                t = t.GetGenericArguments().First<Type>();
            }

            if (t.IsArray)
            {
                t = t.GetElementType();
            }
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Enum @enum in Enum.GetValues(t).OfType<Enum>())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = Enum.Parse(t, @enum.ToString()).ToString();
                selectListItem.Text = @enum.GetEnumDescription();
                selectListItem.Selected = @enum.Equals(metadata.Model);
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{1}{0}" : "{0}{1}";

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

            string validationHtml = string.Empty;
            if (!showValidationMessageInline)
            {
                validationHtml = RenderValidationMessage();
            }

            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, validationHtml)).ToString();
        }
    }
}