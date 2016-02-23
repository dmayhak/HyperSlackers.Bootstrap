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
			AddClass("alert");
            Style(alertStyle); // ensures that the attribute gets added
        }

        public Alert(AlertStyle style)
            : base("div")
        {
            AddClass("alert");
            alertStyle = style;
            Style(style); // ensures that the attribute gets added
        }

        public Alert Dismissible()
		{
            Contract.Ensures(Contract.Result<Alert>() != null);

			isDismissible = true;
            AddClass("alert-dismissible");

			return this;
		}

        public Alert IsLongMessage()
		{
            Contract.Ensures(Contract.Result<Alert>() != null);

            AddClass("alert-block");

			return this;
		}

        public Alert Style(AlertStyle style)
        {
            Contract.Ensures(Contract.Result<Alert>() != null);

            RemoveClass(Helpers.GetCssClass(alertStyle)); // remove old class
            alertStyle = style;
            AddClass(Helpers.GetCssClass(alertStyle)); // add new class

            return this;
        }
	}
}