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
        public ControlGroupControl<TModel> CustomControls(string controls)
        {
            Contract.Requires<ArgumentException>(!controls.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            IHtmlString[] htmlStrings = new IHtmlString[] { MvcHtmlString.Create(controls) };

            return CustomControls(htmlStrings);
        }

        public ControlGroupControl<TModel> CustomControls(params IHtmlString[] controls)
        {
            Contract.Requires<ArgumentNullException>(controls != null, "controls");
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            List<IHtmlString> controlList = new List<IHtmlString>();
            foreach (var item in controls)
            {
                controlList.Add(item);
            }

            return new ControlGroupControl<TModel>(html, controlList);
        }
    }
}