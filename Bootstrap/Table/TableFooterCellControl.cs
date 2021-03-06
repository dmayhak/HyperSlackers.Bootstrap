﻿using HyperSlackers.Bootstrap.Core;
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
    public class TableFooterCellControl : TableCellControlBase<TableFooterCellControl, TableFooterCell>
    {
        public TableFooterCellControl(string htmlText)
            : base(htmlText)
        {
        }
        public TableFooterCellControl(IHtmlString htmlText)
            : base(htmlText)
        {
        }
    }
}