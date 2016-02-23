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
    public partial class BootstrapHelpers<TModel>
    {
        public FormBuilder<TModel> CurrentForm() // returns the current formbuilder OR a dummy (non-rendering) one if null (like in a partial view ajax request or html helper)
        {
            Contract.Ensures(Contract.Result<FormBuilder<TModel>>() != null);

            Form form = html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] as Form;
            if (form != null)
            {
                return new FormBuilder<TModel>(html, form, true);
            }

            return new FormBuilder<TModel>(html, new Form("dummyForm"), true);
        }
    }
}