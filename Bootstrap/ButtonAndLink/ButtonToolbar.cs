using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class ButtonToolbar : HtmlElement<ButtonToolbar>
    {
        internal ButtonStyle style = ButtonStyle.Default;
        internal ButtonSize size = ButtonSize.Default;

        public ButtonToolbar()
            : base(string.Empty)
        {
        }

        public ButtonToolbar Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<ButtonToolbar>() != null);

            this.style = style;

            return this;
        }

        public ButtonToolbar Size(ButtonSize size)
        {
            Contract.Ensures(Contract.Result<ButtonToolbar>() != null);

            this.size = size;

            return this;
        }
    }
}