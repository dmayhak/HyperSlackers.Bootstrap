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
        public ModalBuilder<TModel> BeginModal(Modal modal)
        {
            Contract.Requires<ArgumentNullException>(modal != null, "modal");
            Contract.Ensures(Contract.Result<ModalBuilder<TModel>>() != null);

            return new ModalBuilder<TModel>(html, modal);
        }
    }
}