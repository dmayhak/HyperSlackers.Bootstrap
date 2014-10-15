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
    public class TableRow : HtmlElement<TableRow>
    {
        public TableRow()
            : base("tr")
        {
        }

        public TableRow Active(bool isActive = true)
        {
            Contract.Ensures(Contract.Result<TableRow>() != null);

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

        public TableRow Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableRow>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }
    }
}