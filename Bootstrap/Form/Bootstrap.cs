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
        public FormBuilder<TModel> BeginForm(Form form)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");
            Contract.Ensures(Contract.Result<FormBuilder<TModel>>() != null);

            return new FormBuilder<TModel>(this.html, form);
        }

        public SectionBuilder<TModel> BeginSection(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<SectionBuilder<TModel>>() != null);

            return new SectionBuilder<TModel>(this.html, id);
        }
    }
}