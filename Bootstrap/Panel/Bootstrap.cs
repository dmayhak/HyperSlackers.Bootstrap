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
        public PanelBuilder<TModel> BeginPanel(Panel panel)
        {
            Contract.Requires<ArgumentNullException>(panel != null, "panel");
            Contract.Ensures(Contract.Result<PanelBuilder<TModel>>() != null);

            return new PanelBuilder<TModel>(html, panel);
        }
    }
}