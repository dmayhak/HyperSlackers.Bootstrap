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
        internal bool dropup;

		public DropDown(string actionText) 
            : base(string.Empty)
		{
            Contract.Requires<ArgumentNullException>(actionText != null, "actionText");

            this.actionText = actionText;
		}

        public DropDown AlignTo(DropDownAlignment direction)
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

            allignToDirection = direction;

			return this;
        }

        public DropDown Dropup(bool dropup = true)
        {
            Contract.Ensures(Contract.Result<DropDown>() != null);

            this.dropup = dropup;

            return this;
        }

        public DropDown SetLinksActiveByController()
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

            activeLinksByController = true;

			return this;
		}

		public DropDown SetLinksActiveByControllerAndAction()
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

            activeLinksByControllerAndAction = true;

			return this;
		}

		public DropDown Size(ButtonSize size)
		{
            Contract.Ensures(Contract.Result<DropDown>() != null);

            buttonSize = size;

			return this;
		}

        public DropDown Style(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<DropDown>() != null);

            buttonStyle = style;

            return this;
        }
	}
}