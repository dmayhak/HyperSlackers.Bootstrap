using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Core;
using System.Linq.Expressions;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class RadioButtonListControl<TModel, TSource, SValue, SText> : InputControlListBase<RadioButtonListControl<TModel, TSource, SValue, SText>, TModel, TSource, SValue, SText>
    {
        internal RadioButtonListControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression) 
            : base(html, htmlFieldName, metadata, sourceDataExpression, valueExpression, textExpression)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
		}

        internal RadioButtonListControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
            : base(html, htmlFieldName, metadata, sourceData, valueExpression, textExpression)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
		}

        protected override string RenderControlListItem(int index, string inputValue, string inputText, IDictionary<string, object> inputHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(this.htmlFieldName);
            string controlHtml = string.Empty;
            IDictionary<string, object> attributes = labelHtmlAttributes;

            RadioButtonControl<TModel> radioButton = new RadioButtonControl<TModel>(this.html, this.htmlFieldName, inputValue, this.metadata);
            radioButton.ControlHtmlAttributes(inputHtmlAttributes.FormatHtmlAttributes());
            radioButton.ControlId(fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString());
            radioButton.IsChecked(inputIsChecked);
            radioButton.Disabled(inputIsDisabled);
            radioButton.Label(inputText);
            radioButton.index = index;
            radioButton.LabelHtmlAttributes(labelHtmlAttributes);
            radioButton.LabelShowRequiredStar(false);

            return "<div class='radio{1}'>{0}</div>".FormatWith(radioButton.ToHtmlString(), (displayInlineBlock ? " checkbox-inline" : ""));
        }
    }
}
