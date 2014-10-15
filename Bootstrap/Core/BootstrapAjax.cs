using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.BootstrapMethods;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
	public partial class BootstrapAjax<TModel>
	{
        internal readonly AjaxHelper<TModel> ajax;

        internal BootstrapAjax(AjaxHelper<TModel> ajax) 
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");

            this.ajax = ajax;
		}
	}
}