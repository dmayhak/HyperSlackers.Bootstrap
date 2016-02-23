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
        /// Creates a Bootstrap <see cref="Well"/>.
        /// </summary>
        /// <param name="well">The well.</param>
        /// <returns></returns>
        public WellBuilder<TModel> BeginWell(Well well)
        {
            Contract.Requires<ArgumentNullException>(well != null, "well");
            Contract.Ensures(Contract.Result<WellBuilder<TModel>>() != null);

            return new WellBuilder<TModel>(html, well);
        }

        /// <summary>
        /// Creates a Bootstrap <see cref="Well"/>.
        /// </summary>
        /// <param name="size">The <see cref="WellSize"/>.</param>
        /// <returns>A <see cref="WellBuilder"/> object.</returns>
        public WellBuilder<TModel> BeginWell(WellSize size = WellSize.Default)
        {
            Contract.Ensures(Contract.Result<WellBuilder<TModel>>() != null);

            return new WellBuilder<TModel>(html, new Well().Size(size));
        }

        /// <summary>
        /// Creates a Bootstrap <see cref="Well"/>.
        /// </summary>
        /// <param name="content">The well content.</param>
        /// <param name="size">The well size.</param>
        /// <returns></returns>
        public WellControl<TModel> Well(string content, WellSize size = WellSize.Default)
        {
            Contract.Requires<ArgumentException>(!content.IsNullOrWhiteSpace());

            return new WellControl<TModel>(html, content);
        }
    }
}