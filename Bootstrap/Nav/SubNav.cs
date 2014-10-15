using System;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class SubNav : Nav
	{
        readonly internal string text;
        readonly internal string url;

		public SubNav(string text, string url) 
            : base(true)
		{
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());

			this.text = text;
			this.url = url;
		}

		public new SubNav SetLinksActiveByController()
		{
            Contract.Ensures(Contract.Result<SubNav>() != null);

			this.activeLinksByController = true;

			return this;
		}

		public new SubNav SetLinksActiveByControllerAndAction()
		{
            Contract.Ensures(Contract.Result<SubNav>() != null);

			this.activeLinksByControllerAndAction = true;

			return this;
		}
	}
}