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
    public class TableRowBuilder<TModel> : DisposableHtmlElement<TModel, TableRow>
    {
        internal TableRowBuilder(HtmlHelper<TModel> html, TableRow row)
            : base(html, row)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(row != null, "row");

            this.textWriter.Write(this.element.StartTag);
        }

        public TableCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            return new TableCellBuilder<TModel>(this.html, new TableCell());
        }

        public TableCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            TableCell tableCell = (new TableCell()).HtmlAttributes(htmlAttributes);

            return new TableCellBuilder<TModel>(this.html, tableCell);
        }

        public TableCellBuilder<TModel> BeginCell(TableCell tableCell)
        {
            Contract.Requires<ArgumentNullException>(tableCell != null, "tableCell");
            Contract.Ensures(Contract.Result<TableCellBuilder<TModel>>() != null);

            return new TableCellBuilder<TModel>(this.html, tableCell);
        }

        public TableCellControl Cell(IHtmlString html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(html);
        }

        public TableCellControl Cell(string html)
        {
            //x Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableCellControl>() != null);

            return new TableCellControl(MvcHtmlString.Create(html));
        }
    }
}