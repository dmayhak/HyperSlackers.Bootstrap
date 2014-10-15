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
    public class TableHeaderRow : HtmlElement<TableHeaderRow>
    {
        public TableHeaderRow()
            : base("tr")
        {
        }

        public TableHeaderRow Active()
        {
            Contract.Ensures(Contract.Result<TableHeaderRow>() != null);

            base.AddClass("active");

            return this;
        }

        public TableHeaderRow Active(bool isActive)
        {
            Contract.Ensures(Contract.Result<TableHeaderRow>() != null);

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

        public TableHeaderRow Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableHeaderRow>() != null);

            base.AddClass(Helpers.GetCssClass(style));

            return this;
        }
    }
}