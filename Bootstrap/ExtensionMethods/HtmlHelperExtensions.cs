using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.BootstrapMethods;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Controls;
using System.Linq.Expressions;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public static class HtmlHelperExtensions
    {
        private static Dictionary<Expression, AuthorizeAttribute[]> expressionAuthorizers = new Dictionary<Expression, AuthorizeAttribute[]>();

        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "helper");
            Contract.Ensures(Contract.Result<Bootstrap<TModel>>() != null);

            return new Bootstrap<TModel>(html);
        }

        public static BootstrapAjax<TModel> Bootstrap<TModel>(this AjaxHelper<TModel> html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "helper");
            Contract.Ensures(Contract.Result<BootstrapAjax<TModel>>() != null);

            return new BootstrapAjax<TModel>(html);
        }

        internal static Defaults BootstrapDefaults(this HtmlHelper html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<Defaults>() != null);

            return new Defaults(html);
        }

        internal static bool IsAuthorized<TController>(this HtmlHelper html, Expression<Action<TController>> action)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(action != null, "action");

            var callExpression = action.Body as MethodCallExpression;

            if (callExpression == null)
            {
                return false;
            }

            var authAttributes = expressionAuthorizers.ContainsKey(action) ? expressionAuthorizers[action] : expressionAuthorizers[action] = GetAttributes<AuthorizeAttribute>(callExpression);

            return (authAttributes.Length > 0) ? authAttributes.All(a => a.IsAuthorized(html.ViewContext.HttpContext.User)) : true;
        }

        private static TAttribute[] GetAttributes<TAttribute>(MethodCallExpression callExpression) where TAttribute : Attribute
        {
            Contract.Requires<ArgumentNullException>(callExpression != null, "callExpression");

            return callExpression.Object.Type.GetCustomAttributes(typeof(TAttribute), true)
                .Union(callExpression.Method.GetCustomAttributes(typeof(TAttribute), true))
                .Cast<TAttribute>()
                .ToArray();
        }
    }
}
