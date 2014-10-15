using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public RadioButtonControl<TModel> RadioButton(string htmlFieldName, object value)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonControl<TModel>>() != null);

            return new RadioButtonControl<TModel>(this.html, htmlFieldName, value, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public RadioButtonControl<TModel> RadioButtonFor<TValue>(Expression<Func<TModel, TValue>> expression, object value)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonControl<TModel>>() != null);

            return new RadioButtonControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), value, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(string htmlFieldName, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData), sourceDataExpression, valueExpression, textExpression);
        }

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(string htmlFieldName, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData), sourceData, valueExpression, textExpression);
        }

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData), sourceDataExpression, valueExpression, textExpression);
        }

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData), sourceData, valueExpression, textExpression);
        }

        public RadioButtonListFromEnumControl<TModel> RadioButtonsFromEnum(string htmlFieldName)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            return new RadioButtonListFromEnumControl<TModel>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public RadioButtonListFromEnumControl<TModel> RadioButtonsFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            return new RadioButtonListFromEnumControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }

        public RadioButtonTrueFalseControl<TModel> RadioButtonTrueFalse(string htmlFieldName)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            return new RadioButtonTrueFalseControl<TModel>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public RadioButtonTrueFalseControl<TModel> RadioButtonTrueFalseFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            return new RadioButtonTrueFalseControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }
    }
}