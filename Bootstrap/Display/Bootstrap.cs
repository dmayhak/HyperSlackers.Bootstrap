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
        public DisplayControl<TModel> Display(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            return new DisplayControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public DisplayControl<TModel> DisplayFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            return new DisplayControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public DisplayTextControl<TModel> DisplayText(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayTextControl<TModel>>() != null);

            return new DisplayTextControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public DisplayTextControl<TModel> DisplayTextFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DisplayTextControl<TModel>>() != null);

            return new DisplayTextControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }
    }
}