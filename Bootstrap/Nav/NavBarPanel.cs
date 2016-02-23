using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class NavBarPanel : HtmlElement<NavBarPanel> // TODO:  WIP
    {
        internal bool alignRight;

        public NavBarPanel()
            : base("ul")
		{
        }

        public NavBarPanel AlignRight()
        {
            Contract.Ensures(Contract.Result<NavBarPanel>() != null);

            alignRight = true;

            return this;
        }
    }
}
