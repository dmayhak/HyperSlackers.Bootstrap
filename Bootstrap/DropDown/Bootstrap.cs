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
        public DropDownBuilder<TModel> BeginDropDown(string actionText)
        {
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(html, new DropDown(actionText), "div", new { @class = "dropdown" }, true);
        }

        public DropDownBuilder<TModel> BeginDropDown(DropDown dropDown)
        {
            Contract.Requires<ArgumentNullException>(dropDown != null, "dropDown");
            Contract.Ensures(Contract.Result<DropDownBuilder<TModel>>() != null);

            return new DropDownBuilder<TModel>(html, dropDown, "div", new { @class = dropDown.dropup ? "dropup" : "dropdown" }, true);
        }

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, string optionlabel)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!optionlabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, htmlFieldName, optionlabel, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public DropDownListControl<TModel> DropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public DropDownListFromEnumControl<TModel, TValue> DropDownListFromEnum<TValue>(string htmlFieldName)
        where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            return new DropDownListFromEnumControl<TModel, TValue>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public DropDownListFromEnumControl<TModel, TValue> DropDownListFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            return new DropDownListFromEnumControl<TModel, TValue>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData));
        }

        public DropDownMenuControl<TModel> DropDownMenu()
        {
            Contract.Ensures(Contract.Result<DropDownMenuControl<TModel>>() != null);

            return new DropDownMenuControl<TModel>(html);
        }

        public DropDownMenuButtonControl<TModel> DropDownMenuButton(DropDown dropdown)
        {
            Contract.Ensures(Contract.Result<DropDownMenuButtonControl<TModel>>() != null);

            return new DropDownMenuButtonControl<TModel>(html, dropdown);
        }
    }
}