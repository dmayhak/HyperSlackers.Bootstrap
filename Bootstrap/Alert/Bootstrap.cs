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
        public AlertControl<TModel> Alert(string alertHtml, AlertStyle style = AlertStyle.Danger)
        {
            Contract.Requires<ArgumentException>(!alertHtml.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<AlertControl<TModel>>() != null);

            return new AlertControl<TModel>(html, alertHtml).Style(style);
        }

        public AlertBuilder<TModel> BeginAlert(AlertStyle style = AlertStyle.Danger)
        {
            Contract.Ensures(Contract.Result<AlertBuilder<TModel>>() != null);

            return BeginAlert(new Alert(style));
        }

        public AlertBuilder<TModel> BeginAlert(Alert alert)
        {
            Contract.Requires<ArgumentNullException>(alert != null, "alert");
            Contract.Ensures(Contract.Result<AlertBuilder<TModel>>() != null);

            return new AlertBuilder<TModel>(html, alert);
        }

        public MessageAlertControl<TModel> MessageAlerts()
        {
            Contract.Ensures(Contract.Result<MessageAlertControl<TModel>>() != null);

            return new MessageAlertControl<TModel>(html);
        }
    }
}