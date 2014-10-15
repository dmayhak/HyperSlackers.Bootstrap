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
using HyperSlackers.Bootstrap.Builders;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public TableBuilder<TModel> BeginTable(Table table)
        {
            Contract.Requires<ArgumentNullException>(table != null, "table");
            Contract.Ensures(Contract.Result<TableBuilder<TModel>>() != null);

            return new TableBuilder<TModel>(this.html, table);
        }
    }
}