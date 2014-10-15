using HyperSlackers.Bootstrap.Core;
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

namespace HyperSlackers.Bootstrap.Controls
{
    public class CheckBoxListFromEnumControl<TModel> : ControlListBase<CheckBoxListFromEnumControl<TModel>, TModel>
    {
        internal bool displayInlineBlock;
        internal readonly List<Tuple<dynamic, dynamic>> controlDataAttributesFromFunc = new List<Tuple<object, object>>();
        internal readonly List<Tuple<dynamic, dynamic>> controlHtmlAttributesFromFunc = new List<Tuple<object, object>>();
        internal readonly List<Tuple<dynamic, dynamic>> labelDataAttributesFromFunc = new List<Tuple<object, object>>();
        internal readonly List<Tuple<dynamic, dynamic>> labelHtmlAttributesFromFunc = new List<Tuple<object, object>>();
        internal int marginRightPx;

        internal CheckBoxListFromEnumControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
		}

        public CheckBoxListFromEnumControl<TModel> DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        public CheckBoxListFromEnumControl<TModel> DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;
            this.displayInColumnsCondition = condition;

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        public CheckBoxListFromEnumControl<TModel> DisplayInlineBlock(int marginRightPx = 0)
        {
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            this.displayInlineBlock = true;
            this.marginRightPx = marginRightPx;

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        public CheckBoxListFromEnumControl<TModel> ControlHtmlDataAttributes<TEnum>(Func<TEnum, object> htmlDataAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlDataAttributesFunc != null, "htmlDataAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                this.controlDataAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlDataAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        public CheckBoxListFromEnumControl<TModel> ControlHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                this.controlHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        public CheckBoxListFromEnumControl<TModel> LabelHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                this.labelHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel>)this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            Type t = this.metadata.ModelType;
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var e in Enum.GetValues(t).OfType<Enum>())
            {
                listItems.Add(new SelectListItem()
                {
                    Text = e.GetEnumDescription(),
                    Value = Enum.Parse(t, e.ToString()).ToString(),
                    Selected = e.Equals(this.metadata.Model)
                });
            }

            List<string> inputs = new List<string>();

            int index = 0;
            foreach (var item in listItems)
            {
                inputs.Add(RenderControlListItem(
                    index,
                    item.Value,
                    item.Text,
                    null,
                    null,
                    item.Selected,
                    this.isDisabled));
                index++;
            }

            return RenderControlListContainer(inputs);
        }

        protected override string RenderControlListItem(int index, string inputValue, string inputText, IDictionary<string, object> inputHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = this.html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            CheckBoxControl<TModel> checkBox = new CheckBoxControl<TModel>(this.html, this.htmlFieldName, this.metadata, inputValue, false);
            checkBox.ControlHtmlAttributes(inputHtmlAttributes.FormatHtmlAttributes());
            checkBox.ControlId(fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString());
            checkBox.IsChecked(inputIsChecked);
            checkBox.Disabled(inputIsDisabled);

            checkBox.Label(inputText);
            checkBox.index = index;
            checkBox.LabelHtmlAttributes(labelHtmlAttributes);
            checkBox.LabelShowRequiredStar(false);

            if (this.displayInlineBlock)
            {
                checkBox.ControlClass("checkbox-inline");
            }

            return checkBox.ToHtmlString();
        }

        
    }
}
