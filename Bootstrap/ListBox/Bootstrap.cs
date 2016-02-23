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
        public ListBoxControl<TModel> ListBox(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            return new ListBoxControl<TModel>(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public ListBoxControl<TModel> ListBoxFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            return new ListBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }
    }
}