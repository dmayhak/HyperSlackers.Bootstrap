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
    public class CheckBoxListFromEnumControl<TModel, TValue> : ControlListBase<CheckBoxListFromEnumControl<TModel, TValue>, TModel>
        where TValue : struct, IConvertible

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
            Contract.Requires<ArgumentException>(typeof(TValue).IsEnum);

        }

        public CheckBoxListFromEnumControl<TModel, TValue> DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        public CheckBoxListFromEnumControl<TModel, TValue> DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;
            displayInColumnsCondition = condition;

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        public CheckBoxListFromEnumControl<TModel, TValue> DisplayInlineBlock(int marginRightPx = 0)
        {
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            displayInlineBlock = true;
            this.marginRightPx = marginRightPx;

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        public CheckBoxListFromEnumControl<TModel, TValue> ControlHtmlDataAttributes<TEnum>(Func<TEnum, object> htmlDataAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlDataAttributesFunc != null, "htmlDataAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                controlDataAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlDataAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        public CheckBoxListFromEnumControl<TModel, TValue> ControlHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                controlHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        public CheckBoxListFromEnumControl<TModel, TValue> LabelHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                labelHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (CheckBoxListFromEnumControl<TModel, TValue>)this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            Type t = typeof(TValue);
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var e in Enum.GetValues(t).OfType<Enum>())
            {
                listItems.Add(new SelectListItem()
                {
                    Text = e.GetEnumDescription(),
                    Value = Enum.Parse(t, e.ToString()).ToString(),
                    Selected = e.Equals(metadata.Model)
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
                    isDisabled));
                index++;
            }

            return RenderControlListContainer(inputs);
        }

        protected override string RenderControlListItem(int index, string inputValue, string inputText, IDictionary<string, object> inputHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            CheckBoxControl<TModel> checkBox = new CheckBoxControl<TModel>(html, htmlFieldName, metadata, inputValue, false);
            checkBox.ControlHtmlAttributes(inputHtmlAttributes.FormatHtmlAttributes());
            checkBox.ControlId(fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString());
            checkBox.IsChecked(inputIsChecked);
            checkBox.Disabled(inputIsDisabled);

            checkBox.Label(inputText);
            checkBox.index = index;
            checkBox.LabelHtmlAttributes(labelHtmlAttributes);
            checkBox.LabelShowRequiredStar(false);

            if (displayInlineBlock)
            {
                checkBox.ControlClass("checkbox-inline");
            }

            return checkBox.ToHtmlString();
        }


    }
}
