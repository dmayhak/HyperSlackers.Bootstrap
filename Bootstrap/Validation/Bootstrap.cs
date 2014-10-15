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
        /// <summary>
        /// Creates a <see cref="ValidationSummaryControl{TModel}"/>.
        /// </summary>
        /// <returns></returns>
        public ValidationSummaryControl<TModel> ValidationSummary()
        {
            Contract.Ensures(Contract.Result<ValidationSummaryControl<TModel>>() != null);

            return new ValidationSummaryControl<TModel>(this.html);
        }
    }
}