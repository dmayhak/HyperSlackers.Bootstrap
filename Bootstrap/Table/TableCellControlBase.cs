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
    public class TableCellControlBase<T, TCell> : HtmlStringBase<T>
        where T : TableCellControlBase<T, TCell>
        where TCell : TableCellBase<TCell>, new()
    {
        readonly protected IHtmlString htmlText;
        internal TCell cell = new TCell();

        public TableCellControlBase(string htmlText)
        {
            this.htmlText = MvcHtmlString.Create(htmlText);
        }

        public TableCellControlBase(IHtmlString htmlText)
        {
            this.htmlText = htmlText;
        }

        public T ColSpan(int span)
        {
            Contract.Requires<ArgumentOutOfRangeException>(span > 0);
            Contract.Ensures(Contract.Result<T>() != null);

            cell.ColSpan(span);

            return (T)this;
        }

        public T Style(TableColor style)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            cell.Style(style);

            return (T)this;
        }

        public T Align(TextAlign align)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            cell.Align(align);

            return (T)this;
        }

        public T Width(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<T>() != null);

            cell.Width(width);

            return (T)this;
        }

        public T Width(string width)
        {
            Contract.Requires<ArgumentNullException>(width != null, "width");
            Contract.Requires<ArgumentException>(!width.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<T>() != null);

            cell.Width(width);

            return (T)this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            // merge attributes from this to the cell prior to rendering
            cell.HtmlAttributes(attributes);

            return cell.ToHtmlString(htmlText.ToHtmlString());
        }
    }
}