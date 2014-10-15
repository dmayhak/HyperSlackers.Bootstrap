using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class ButtonGroup : HtmlElement<ButtonGroup>
	{
		internal bool justified;
		internal bool vertical;
        internal ButtonStyle style = ButtonStyle.Default;
        internal ButtonSize size = ButtonSize.Default;

		public ButtonGroup() 
            : base(string.Empty)
		{
		}

		public ButtonGroup Justified()
        {
            Contract.Ensures(Contract.Result<ButtonGroup>() != null);

            this.justified = true;
            
            return this;
        }

        public ButtonGroup Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<ButtonGroup>() != null);

            this.style = style;

            return this;
        }

        public ButtonGroup Size(ButtonSize size)
        {
            Contract.Ensures(Contract.Result<ButtonGroup>() != null);

            this.size = size;

            return this;
        }

        public ButtonGroup Vertical(bool vertical = true)
		{
            Contract.Ensures(Contract.Result<ButtonGroup>() != null);

			this.vertical = vertical;

			return this;
		}
	}
}