using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Builders
{
    public class TableCellBuilder<TModel> : DisposableHtmlElement<TModel, TableCell>
    {
        internal TableCellBuilder(HtmlHelper<TModel> html, TableCell cell)
            : base(html, cell)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(cell != null, "cell");

            this.textWriter.Write(this.element.StartTag);
        }
    }
}