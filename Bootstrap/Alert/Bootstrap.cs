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
        public AlertControl<TModel> Alert(string alertHtml)
        {
            Contract.Requires<ArgumentException>(!alertHtml.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            return new AlertControl<TModel>(this.html, alertHtml);
        }

        public AlertBuilder<TModel> BeginAlert(Alert alert)
        {
            Contract.Requires<ArgumentNullException>(alert != null, "alert");
            Contract.Ensures(Contract.Result<AlertBuilder<TModel>>() != null);

            return new AlertBuilder<TModel>(this.html, alert);
        }

        public MessageAlertControl<TModel> MessageAlerts()
        {
            Contract.Ensures(Contract.Result<MessageAlertControl<TModel>>() != null);

            return new MessageAlertControl<TModel>(this.html);
        }
    }
}