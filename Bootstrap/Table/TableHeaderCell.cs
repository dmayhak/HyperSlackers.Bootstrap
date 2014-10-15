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
    public class TableHeaderCell : HtmlElement<TableHeaderCell>
    {
        public TableHeaderCell()
            : base("th")
        {
        }

        public TableHeaderCell ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableHeaderCell>() != null);

            this.AddOrMergeHtmlAttribute("colspan", span.ToString());

            return this;
        }

        public TableHeaderCell Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableHeaderCell>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }

        public TableHeaderCell Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableHeaderCell>() != null);

            base.AddClass(Helpers.GetCssClass(width));

            return this;
        }

        public TableHeaderCell Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableHeaderCell>() != null);

            this.HtmlAttribute("width", width);
            
            return this;
        }
    }
}