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
        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(this.html, dropDown, "div", new { @class = "dropdown" }, true);
        }

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(this.html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, string optionlabel)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!optionlabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(this.html, htmlFieldName, optionlabel, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public DropDownListControl<TModel> DropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }

        public DropDownListFromEnumControl<TModel> DropDownListFromEnum(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            return new DropDownListFromEnumControl<TModel>(this.html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, this.html.ViewData));
        }

        public DropDownListFromEnumControl<TModel> DropDownListFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel>>() != null);

            return new DropDownListFromEnumControl<TModel>(this.html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, this.html.ViewData));
        }

        public DropDownMenuControl<TModel> DropDownMenu()
        {
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

            return new DropDownMenuControl<TModel>(this.html);
        }
    }
}