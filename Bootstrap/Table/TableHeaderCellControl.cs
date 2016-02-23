using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class TableHeaderCellControl : TableCellControlBase<TableHeaderCellControl, TableHeaderCell>
    {
        public TableHeaderCellControl(string htmlText)
            : base(htmlText)
        {
        }
        public TableHeaderCellControl(IHtmlString htmlText)
            : base(htmlText)
        {
        }
    }
}