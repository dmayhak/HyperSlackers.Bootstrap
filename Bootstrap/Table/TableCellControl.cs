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
    public class TableCellControl : HtmlStringBase<TableCellControl>
    {
        readonly private IHtmlString htmlText;
        readonly internal bool isHeader;
        internal TableCell cell = new TableCell();

        public TableCellControl(IHtmlString htmlText)
        {
            this.htmlText = htmlText;
            this.isHeader = false;
        }

        public TableCellControl ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            this.cell.ColSpan(span);

            return this;
        }

        public TableCellControl Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            this.cell.Style(style);

            return this;
        }

        public TableCellControl Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            this.cell.Align(align);

            return this;
        }

        public TableCellControl Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            this.cell.Width(width);

            return this;
        }

        public TableCellControl Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            this.cell.Width(width);

            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return this.cell.ToHtmlString(this.htmlText.ToHtmlString());
        }
    }
}