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
        public HelpTextControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(text));
            Contract.Ensures(Contract.Result<HelpTextControl<TModel>>() != null);

            return new HelpTextControl<TModel>(html, text);
        }

        public HelpTextControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<HelpTextControl<TModel>>() != null);

            return new HelpTextControl<TModel>(this.html, html.ToHtmlString());
        }
    }
}