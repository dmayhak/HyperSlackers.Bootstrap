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
        public TabsBuilder<TModel> BeginTabs(Tabs tabs)
        {
            Contract.Requires<ArgumentNullException>(tabs != null, "tabs");
            Contract.Ensures(Contract.Result<TabsBuilder<TModel>>() != null);

            return new TabsBuilder<TModel>(this.html, tabs);
        }
    }
}