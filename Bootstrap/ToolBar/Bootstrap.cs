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
        public ToolBarBuilder<TModel> BeginToolBar()
        {
            Contract.Ensures(Contract.Result<ToolBarBuilder<TModel>>() != null);

            return new ToolBarBuilder<TModel>(html, new ToolBar());
        }

        public ToolBarBuilder<TModel> BeginToolBar(string id)
        {
            Contract.Requires<ArgumentNullException>(!id.IsNullOrWhiteSpace(), "id");
            Contract.Ensures(Contract.Result<ToolBarBuilder<TModel>>() != null);

            return new ToolBarBuilder<TModel>(html, new ToolBar().Id(id));
        }

        public ToolBarBuilder<TModel> BeginToolBar(ToolBar toolBar)
        {
            Contract.Requires<ArgumentNullException>(toolBar != null, "toolBar");
            Contract.Ensures(Contract.Result<ToolBarBuilder<TModel>>() != null);

            return new ToolBarBuilder<TModel>(html, toolBar);
        }
    }
}