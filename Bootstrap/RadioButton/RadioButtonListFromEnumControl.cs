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
    public class RadioButtonListFromEnumControl<TModel> : ControlListBase<RadioButtonListFromEnumControl<TModel>, TModel>
    {
        internal bool displayInlineBlock;
        internal List<Tuple<dynamic, dynamic>> controlHtmlDataAttributesFromFunc = new List<Tuple<object, object>>();
        internal List<Tuple<dynamic, dynamic>> controlHtmlAttributesFromFunc = new List<Tuple<object, object>>();
        internal List<Tuple<dynamic, dynamic>> labelHtmlDataAttributesFromFunc = new List<Tuple<object, object>>();
        internal List<Tuple<dynamic, dynamic>> labelHtmlAttributesFromFunc = new List<Tuple<object, object>>();
        internal int marginRightPx;

        internal RadioButtonListFromEnumControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
		}

        public RadioButtonListFromEnumControl<TModel> DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;

            return (RadioButtonListFromEnumControl<TModel>)this;
        }

        public RadioButtonListFromEnumControl<TModel> DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;
            displayInColumnsCondition = condition;

            return (RadioButtonListFromEnumControl<TModel>)this;
        }

        public RadioButtonListFromEnumControl<TModel> DisplayInlineBlock(int marginRightPx = 0)
        {
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            displayInlineBlock = true;
            this.marginRightPx = marginRightPx;

            return (RadioButtonListFromEnumControl<TModel>)this;
        }

        public RadioButtonListFromEnumControl<TModel> ControlHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                controlHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (RadioButtonListFromEnumControl<TModel>)this;
        }

        public RadioButtonListFromEnumControl<TModel> LabelHtmlAttributes<TEnum>(Func<TEnum, object> htmlAttributesFunc)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesFunc != null, "htmlAttributesFunc");
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            foreach (TEnum tEnum in Enum.GetValues(typeof(TEnum)).OfType<TEnum>())
            {
                labelHtmlAttributesFromFunc.Add(new Tuple<object, object>((object)tEnum, htmlAttributesFunc(tEnum)));
            }

            return (RadioButtonListFromEnumControl<TModel>)this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            Type t = metadata.ModelType;
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

        protected override string RenderControlListItem(int index, string controlValue, string controlText, IDictionary<string, object> controlHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string formatString = string.Empty;
            string controlHtml = string.Empty;

            RadioButtonControl<TModel> radioButton = new RadioButtonControl<TModel>(html, htmlFieldName, controlValue, metadata);
            radioButton.ControlHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());
            radioButton.ControlId(fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString());
            radioButton.IsChecked(inputIsChecked);
            radioButton.Disabled(inputIsDisabled);
            radioButton.Label(controlText);
            radioButton.index = index;
            radioButton.LabelHtmlAttributes(labelHtmlAttributes);
            radioButton.LabelShowRequiredStar(false);

            if (displayInlineBlock)
            {
                return "<div class='radio checkbox-inline'>{0}</div>".FormatWith(radioButton.ToHtmlString());
            }
            else
            {
                return "<div class='radio'>{0}</div>".FormatWith(radioButton.ToHtmlString());
            }
        }
    }
}
