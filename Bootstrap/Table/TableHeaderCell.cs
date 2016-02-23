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
    public class TableHeaderCell : TableCellBase<TableHeaderCell>
    {
        public TableHeaderCell()
            : base("th")
        {
        }

        public override TableHeaderCell Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<TableHeaderCell>() != null);

            if (align == TextAlign.None)
            {
                base.RemoveHtmlAttribute("align");
                base.RemoveStyle("text-align");
            }
            else
            {
                AddOrReplaceHtmlAttribute("align", align.ToString().ToLowerInvariant());
                AddOrReplaceHtmlAttribute("style", "text-align:{0};".FormatWith(align.ToString().ToLowerInvariant()));
            }

            return this;
        }
    }
}