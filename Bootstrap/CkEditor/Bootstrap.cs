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
        public CkEditorControl<TModel> CkEditor(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            return new CkEditorControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public CkEditorControl<TModel> CkEditorFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            return new CkEditorControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }
    }
}