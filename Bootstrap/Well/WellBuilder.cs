using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// Builder for the Bootstrap<see cref="Well"/>.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class WellBuilder<TModel> : DisposableHtmlElement<TModel, Well>
    {
        internal WellBuilder(HtmlHelper<TModel> html, Well well)
            : base(html, well)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(well != null, "well");

            this.textWriter.Write(this.element.StartTag);
        }
    }
}
