using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class NavBar : HtmlElement<NavBar> // TODO: WIP
    {
        internal NavBarAlignment alignment = NavBarAlignment.StaticTop;
        internal bool inverse;
        internal bool fluidContainer;
        internal string brand;

        public NavBar()
            : base("nav")
        {

        }

        public NavBar Alignment(NavBarAlignment alignment)
        {
            Contract.Ensures(Contract.Result<NavBar>() != null);

            this.alignment = alignment;

            return this;
        }

        public NavBar Inverse(bool inverse = true)
        {
            Contract.Ensures(Contract.Result<NavBar>() != null);

            this.inverse = inverse;

            return this;
        }

        public NavBar FluidContainer(bool fluid = true)
        {
            Contract.Ensures(Contract.Result<NavBar>() != null);

            this.fluidContainer = fluid;

            return this;
        }

        public NavBar Brand(string brand)
        {
            Contract.Requires<ArgumentException>(!brand.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<NavBar>() != null);

            this.brand = brand;

            return this;
        }
    }
}
