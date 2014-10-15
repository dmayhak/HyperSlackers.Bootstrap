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
    public class TableFooterRowBuilder<TModel> : DisposableHtmlElement<TModel, TableFooterRow>
    {
        internal TableFooterRowBuilder(HtmlHelper<TModel> html, TableFooterRow tableFooterRow)
            : base(html, tableFooterRow)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableFooterRow != null, "tableFooterRow");

            this.textWriter.Write(this.element.StartTag);
        }

        public TableFooterCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableFooterCellBuilder<TModel>>() != null);

            return new TableFooterCellBuilder<TModel>(this.html, new TableFooterCell());
        }

        public TableFooterCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableFooterCellBuilder<TModel>>() != null);

            TableFooterCell cell = (new TableFooterCell()).HtmlAttributes(htmlAttributes);

            return new TableFooterCellBuilder<TModel>(this.html, cell);
        }

        public TableFooterCellControl Cell(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(html);
        }

        public TableFooterCellControl Cell(string html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableFooterCellControl>() != null);

            return new TableFooterCellControl(MvcHtmlString.Create(html));
        }
    }
}