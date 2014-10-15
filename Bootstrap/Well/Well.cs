using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    /// <summary>
    /// Use the well as a simple effect on an element to give it an inset effect.
    /// </summary>
    public class Well : HtmlElement<Well>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Well"/> class.
        /// </summary>
        public Well()
            : base("div")
        {
            this.AddClass("well");
        }

        /// <summary>
        /// Sets the size of the <see cref="Well"/>.
        /// </summary>
        /// <param name="size">The <see cref="WellSize"/>.</param>
        /// <returns>The current <see cref="Well"/></returns>
        public Well Size(WellSize size)
        {
            Contract.Ensures(Contract.Result<Well>() != null);

            switch (size)
            {
                case WellSize.Large:
                    this.AddClass("well-lg");
                    break;
                case WellSize.Small:
                    this.AddClass("well-sm");
                    break;
                case WellSize.Default:
                default:
                    break;
            }

            return this;
        }
    }
}
