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
        public TextAreaControl<TModel> TextArea(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            return new TextAreaControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public TextAreaControl<TModel> TextAreaFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            return new TextAreaControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public TextBoxControl<TModel> TextBox(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

            return new TextBoxControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public TextBoxControl<TModel> TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

            return new TextBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public PasswordControl<TModel> Password(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            return new PasswordControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public PasswordControl<TModel> PasswordFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            return new PasswordControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }
    }
}