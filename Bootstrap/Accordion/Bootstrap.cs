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
namespace HyperSlackers.Bootstrap.BootstrapMethods
{

    public partial class Bootstrap<TModel>
    {
        public AccordionBuilder<TModel> BeginAccordion(Accordion accordion)
        {
            Contract.Requires<ArgumentNullException>(accordion != null, "accordion");
            Contract.Ensures(Contract.Result<AccordionBuilder<TModel>>() != null);

            return new AccordionBuilder<TModel>(this.html, accordion);
        }
    }
}