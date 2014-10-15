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
    public class TableCell : HtmlElement<TableCell>
    {
        public TableCell()
            : base("td")
        {
        }

        public TableCell ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableCell>() != null);

            this.AddOrMergeHtmlAttribute("colspan", span.ToString());

            return this;
        }

        public TableCell Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableCell>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }

        public TableCell Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<TableCell>() != null);

            if (align != TextAlign.None)
            {
                base.AddOrMergeHtmlAttribute("align", align.ToString().ToLowerInvariant());
            }

            return this;
        }

        public TableCell Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableCell>() != null);

            base.AddClass(Helpers.GetCssClass(width));

            return this;
        }

        public TableCell Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableCell>() != null);

            this.HtmlAttribute("width", width);
            
            return this;
        }
    }
}