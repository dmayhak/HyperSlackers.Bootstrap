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
using HyperSlackers.Bootstrap.Controls;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class CheckBoxListControl<TModel, TSource, SValue, SText> : InputControlListBase<CheckBoxListControl<TModel, TSource, SValue, SText>, TModel, TSource, SValue, SText>
    {
        internal CheckBoxListControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression) 
            : base(html, htmlFieldName, metadata, sourceDataExpression, valueExpression, textExpression) 
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
		}

        internal CheckBoxListControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
            : base(html, htmlFieldName, metadata, sourceData, valueExpression, textExpression) 
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
		}

        protected override string RenderControlListItem(int index, string controlValue, string controlText, IDictionary<string, object> controlHtmlAttributes, IDictionary<string, object> labelHtmlAttributes, bool inputIsChecked, bool inputIsDisabled)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string formatString = string.Empty;
            
            CheckBoxControl<TModel> checkBox = new CheckBoxControl<TModel>(html, htmlFieldName, metadata);
            checkBox.Value(controlValue);
            checkBox.ControlHtmlAttributes(controlHtmlAttributes.FormatHtmlAttributes());
            checkBox.ControlId(fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString());
            checkBox.IsChecked(inputIsChecked);
            checkBox.Disabled(inputIsDisabled);
            checkBox.index = index;
            checkBox.Label(controlText);
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
