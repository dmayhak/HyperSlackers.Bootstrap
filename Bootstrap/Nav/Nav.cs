using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Nav : HtmlElement
	{
		internal bool activeLinksByController;
		internal bool activeLinksByControllerAndAction;

        public Nav(NavType type = NavType.Tabs) 
            : base("ul")
		{
            AddClass("nav");
            AddClass(Helpers.GetCssClass(type));
        }

		internal Nav(bool isSubNav) 
            : base(string.Empty)
		{
		}

		public Nav Class(string cssClass)
		{
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Nav>() != null);

            AddClass(cssClass);

			return this;
		}

		public Nav Data(object htmlDataAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlDataAttributes != null, "htmlDataAttributes");
            Contract.Ensures(Contract.Result<Nav>() != null);

			base.MergeHtmlDataAttributes(htmlDataAttributes);

			return this;
		}

		public Nav HtmlAttributes(IDictionary<string, object> htmlAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<Nav>() != null);

			base.MergeHtmlAttributes(htmlAttributes);

			return this;
		}

		public Nav HtmlAttributes(object htmlAttributes)
		{
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<Nav>() != null);

			base.MergeHtmlAttributes(htmlAttributes);

			return this;
		}

		public Nav Id(string id)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<Nav>() != null);

            MergeHtmlAttribute("id", id);

			return this;
		}

        public Nav Justified()
        {
            Contract.Ensures(Contract.Result<Nav>() != null);

            AddClass("nav-justified");

            return this;
        }

        public Nav SetLinksActiveByController()
		{
            Contract.Ensures(Contract.Result<Nav>() != null);

            activeLinksByController = true;

			return this;
		}

		public Nav SetLinksActiveByControllerAndAction()
		{
            Contract.Ensures(Contract.Result<Nav>() != null);

            activeLinksByControllerAndAction = true;

			return this;
		}

		public Nav Stacked()
		{
            Contract.Ensures(Contract.Result<Nav>() != null);

            AddClass("nav-stacked");

			return this;
		}

        //public Nav Style(NavType type)
        //{
        //    Contract.Ensures(Contract.Result<Nav>() != null);

        //    AddClass(Helpers.GetCssClass(type));

        //    return this;
        //}
	}
}