using HyperSlackers.Bootstrap.Controls;
using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Builders
{
    public abstract class TableRowBuilderBase<TModel, TRow, TCellBuilder, TCellControl, TCell> : DisposableHtmlElement<TModel, TRow>
        where TRow : TableRowBase<TRow>
        where TCellBuilder : TableCellBuilderBase<TModel, TCell>
        where TCellControl : TableCellControlBase<TCellControl, TCell>
        where TCell : TableCellBase<TCell>, new()
    {
        internal TableRowBuilderBase(HtmlHelper<TModel> html, TRow row)
            : base(html, row)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(row != null, "row");

            textWriter.Write(element.StartTag);
        }

        public abstract TCellBuilder BeginCell();

        public abstract TCellBuilder BeginCell(object htmlAttributes);

        public abstract TCellBuilder BeginCell(TCell tableCell);

        public abstract TCellControl Cell(string html);

        public abstract TCellControl Cell(string html, TextAlign align);

        public abstract TCellControl Cell(string html, TableColor style);

        public abstract TCellControl Cell(string html, int colspan);

        public abstract TCellControl Cell(string html, TextAlign align, TableColor style);

        public abstract TCellControl Cell(string html, TextAlign align, int colspan);

        public abstract TCellControl Cell(string html, TableColor style, int colspan);

        public abstract TCellControl Cell(string html, TextAlign align, TableColor style, int colspan);

        public abstract TCellControl Cell(IHtmlString html);

        public abstract TCellControl Cell(IHtmlString html, TextAlign align);

        public abstract TCellControl Cell(IHtmlString html, TableColor style);

        public abstract TCellControl Cell(IHtmlString html, int colspan);

        public abstract TCellControl Cell(IHtmlString html, TextAlign align, TableColor style);

        public abstract TCellControl Cell(IHtmlString html, TextAlign align, int colspan);

        public abstract TCellControl Cell(IHtmlString html, TableColor style, int colspan);

        public abstract TCellControl Cell(IHtmlString html, TextAlign align, TableColor style, int colspan);
    }
}
