using System;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class DropDown : HtmlElement
	{
        readonly internal string actionText;
		internal bool activeLinksByController;
		internal bool activeLinksByControllerAndAction;
		internal ButtonStyle buttonStyle;
		internal ButtonSize buttonSize;
		internal DropDownAlignment? allignToDirection;

		public DropDown(string actionText) 
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!actionText.IsNullOrWhiteSpace());

			this.actionText = actionText;
		}

        public DropDown AlignTo(DropDownAlignment direction)
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

			this.allignToDirection = direction;
			return this;
		}

		public DropDown SetLinksActiveByController()
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

			this.activeLinksByController = true;

			return this;
		}

		public DropDown SetLinksActiveByControllerAndAction()
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

			this.activeLinksByControllerAndAction = true;

			return this;
		}

		public DropDown Size(ButtonSize size)
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

			this.buttonSize = size;

			return this;
		}

        public DropDown Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<DropDown>() != null);

            this.buttonStyle = style;

            return this;
        }
	}
}