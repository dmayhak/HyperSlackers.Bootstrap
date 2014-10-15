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
        public ModalBuilder<TModel> CurrentModal(bool closable = true) // returns the current modalbuilder OR a dummy (non-rendering) one if null (like in a partial view ajax request...)
        {
            Contract.Ensures(Contract.Result<ModalBuilder<TModel>>() != null);

            Modal modal = this.html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Modal.ToString()] as Modal;
            if (modal != null)
            {
                return new ModalBuilder<TModel>(this.html, modal, true);
            }

            return new ModalBuilder<TModel>(this.html, new Modal().Closeable(closable), true);
        }
    }
}