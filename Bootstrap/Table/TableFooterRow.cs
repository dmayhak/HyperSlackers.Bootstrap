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
    public class TableFooterRow : HtmlElement<TableFooterRow>
    {
        public TableFooterRow()
            : base("tr")
        {
        }

        public TableFooterRow Active()
        {
            Contract.Ensures(Contract.Result<TableFooterRow>() != null);

            base.AddClass("active");

            return this;
        }

        public TableFooterRow Active(bool isActive)
        {
            Contract.Ensures(Contract.Result<TableFooterRow>() != null);

            if (isActive)
            {
                base.AddClass("active");
            }
            else
            {
                base.RemoveClass("active");
            }
            return this;
        }

        public TableFooterRow Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableFooterRow>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }
    }
}