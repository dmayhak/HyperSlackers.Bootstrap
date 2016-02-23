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
        public TreeBuilder<TModel> BeginTree()
        {
            Contract.Ensures(Contract.Result<TreeBuilder<TModel>>() != null);

            return new TreeBuilder<TModel>(html, new Tree());
        }

        public TreeBuilder<TModel> BeginTree(string id)
        {
            Contract.Requires<ArgumentNullException>(!id.IsNullOrWhiteSpace(), "id");
            Contract.Ensures(Contract.Result<TreeBuilder<TModel>>() != null);

            return new TreeBuilder<TModel>(html, new Tree(id));
        }

        public TreeBuilder<TModel> BeginTree(Tree tree)
        {
            Contract.Requires<ArgumentNullException>(tree != null, "tree");
            Contract.Ensures(Contract.Result<TreeBuilder<TModel>>() != null);

            return new TreeBuilder<TModel>(html, tree);
        }
    }
}