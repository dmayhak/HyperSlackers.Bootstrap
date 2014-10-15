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
    public class TableFooterCell : HtmlElement<TableFooterCell>
    {
        public TableFooterCell()
            : base("td")
        {
        }

        public TableFooterCell ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableFooterCell>() != null);

            this.AddOrMergeHtmlAttribute("colspan", span.ToString());

            return this;
        }

        public TableFooterCell Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableFooterCell>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }

        public TableFooterCell Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableFooterCell>() != null);

            base.AddClass(Helpers.GetCssClass(width));

            return this;
        }

        public TableFooterCell Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableFooterCell>() != null);

            this.HtmlAttribute("width", width);

            return this;
        }
    }
}