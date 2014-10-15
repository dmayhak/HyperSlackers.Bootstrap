using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Alert : HtmlElement<Alert>
	{
        internal AlertStyle alertStyle = AlertStyle.Danger;
        internal bool isDismissible;

		public Alert()
            : base("div")
		{
			base.AddClass("alert");
            this.Style(alertStyle); // ensures that the attribute gets added
		}

		public Alert Dismissible()
		{
            Contract.Ensures(Contract.Result<Alert>() != null);

			this.isDismissible = true;
            this.AddClass("alert-dismissible");

			return this;
		}

        public Alert IsLongMessage()
		{
            Contract.Ensures(Contract.Result<Alert>() != null);

            this.AddClass("alert-block");

			return this;
		}

        public Alert Style(AlertStyle style)
        {
            Contract.Ensures(Contract.Result<Alert>() != null);

            this.RemoveClass("alert-danger");
            this.alertStyle = style;
            this.AddClass(Helpers.GetCssClass(alertStyle));

            return this;
        }
	}
}