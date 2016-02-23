using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.Controls;
using HyperSlackers.Bootstrap.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public CheckBoxControl<TModel> CheckBox(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

            return new CheckBoxControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public CheckBoxControl<TModel> CheckBox(string htmlFieldName, object value)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

            return new CheckBoxControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), value, true);
        }

        public CheckBoxListFromEnumControl<TModel, TValue> CheckBoxesFromEnum<TValue>(string htmlFieldName)
            where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            return new CheckBoxListFromEnumControl<TModel, TValue>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public CheckBoxListFromEnumControl<TModel, TValue> CheckBoxesFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
            where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            return new CheckBoxListFromEnumControl<TModel, TValue>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public CheckBoxControl<TModel> CheckBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

            return new CheckBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(string htmlFieldName, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceDataExpression, valueExpression, textExpression);
        }

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(string htmlFieldName, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceData, valueExpression, textExpression);
        }

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceDataExpression, valueExpression, textExpression);
        }

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceData, valueExpression, textExpression);
        }
    }
}
