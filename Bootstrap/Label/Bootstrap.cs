﻿using System;
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
        public LabelControl<TModel> Label(string htmlFieldName)
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

            return new LabelControl<TModel>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public LabelControl<TModel> LabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

            return new LabelControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }
    }
}