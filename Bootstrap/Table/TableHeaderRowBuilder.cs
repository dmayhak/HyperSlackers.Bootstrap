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
    public class TableHeaderRowBuilder<TModel> : DisposableHtmlElement<TModel, TableHeaderRow>
    {
        internal TableHeaderRowBuilder(HtmlHelper<TModel> html, TableHeaderRow tableHeaderRow)
            : base(html, tableHeaderRow)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(tableHeaderRow != null, "tableHeaderRow");

            this.textWriter.Write(this.element.StartTag);
        }

        public TableHeaderCellBuilder<TModel> BeginCell()
        {
            Contract.Ensures(Contract.Result<TableHeaderCellBuilder<TModel>>() != null);

            return new TableHeaderCellBuilder<TModel>(this.html, new TableHeaderCell());
        }

        public TableHeaderCellBuilder<TModel> BeginCell(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TableHeaderCellBuilder<TModel>>() != null);

            TableHeaderCell cell = (new TableHeaderCell()).HtmlAttributes(htmlAttributes);

            return new TableHeaderCellBuilder<TModel>(this.html, cell);
        }

        public TableHeaderCellControl Cell(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(html);
        }

        public TableHeaderCellControl Cell(string html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<TableHeaderCellControl>() != null);

            return new TableHeaderCellControl(MvcHtmlString.Create(html));
        }
    }
}