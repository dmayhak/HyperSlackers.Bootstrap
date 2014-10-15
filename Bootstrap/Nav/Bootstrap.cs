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
        public NavBuilder<TModel> BeginNav(Nav nav)
        {
            Contract.Requires<ArgumentNullException>(nav != null, "nav");
            Contract.Ensures(Contract.Result<NavBuilder<TModel>>() != null);

            return new NavBuilder<TModel>(this.html, nav);
        }
    }
}